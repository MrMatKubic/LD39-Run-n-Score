using LD39.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LD39
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        MenuManager manager;
        Input input;
        SongsManager smanager;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.graphics.PreferredBackBufferWidth = Misc.WindowWidth * (int)Misc.Ratio;
            this.graphics.PreferredBackBufferHeight = Misc.WindowHeight * (int)Misc.Ratio;
            this.graphics.IsFullScreen = Misc.isFullScreen;
            this.IsMouseVisible = Misc.isMouseVisible;
            this.Window.Title = Misc.Title;
            this.input = new Input();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Resources.LoadResources(this.Content);
            this.manager = new MenuManager(MenuState.HOME);
            this.smanager = new SongsManager();
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if(GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            this.input.Update();

            this.manager.Update(gameTime, input);
            this.smanager.Update(gameTime);
            if(MenuManager.menuState.Equals(MenuState.QUIT)) Exit();

            this.input.InitOldStates();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, Matrix.CreateScale(Misc.Ratio));
            this.manager.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
