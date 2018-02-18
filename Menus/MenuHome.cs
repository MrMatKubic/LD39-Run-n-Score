using LD39.Entities;
using LD39.Global;
using LD39.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD39.Menus
{
    public class MenuHome
    {
        // FIELDS
        private EntitySprite background;
        private EntitySprite title;

        private EntityButton startButton;
        private EntityButton quitButton;

        private Text madeFor;

        private EntityAnimatedSprite head1;
        private EntityAnimatedSprite head2;

        // CONSTRUCTORS
        public MenuHome()
        {
            this.head1 = new EntityAnimatedSprite(new AnimatedSprite("playerHead", 1, 1, 10, 1f, 1f));
            this.head1.ESprite.Origin = new Vector2(this.head1.ESprite.Width / 20, this.head1.ESprite.Height / 20);
            this.head1.ESprite.X = 0;
            this.head1.ESprite.Y = Misc.WindowHeight;

            this.head2 = new EntityAnimatedSprite(new AnimatedSprite("playerHead", 1, 1, 10, 1f, 1f));
            this.head2.ESprite.Origin = new Vector2(this.head2.ESprite.Width / 20, this.head2.ESprite.Height / 20);
            this.head2.ESprite.X = Misc.WindowWidth;
            this.head2.ESprite.Y = Misc.WindowHeight;

            this.background = new EntitySprite(new Sprite("home_background", 4, false));
            this.title = new EntitySprite(new Sprite("title", 2, true));
            this.title.ESprite.X = Misc.WindowWidth / 2 - this.title.ESprite.Width / 2;
            this.title.ESprite.Y = Misc.WindowHeight / 2 - this.title.ESprite.Height * 2 - this.title.ESprite.Height / 2;

            this.startButton = new EntityButton("PLAY");
            this.startButton.ESprite.X = Misc.WindowWidth / 2 - this.startButton.ESprite.Width / 2;
            this.startButton.ESprite.Y = Misc.WindowHeight / 2 - this.startButton.ESprite.Height / 2;

            this.quitButton = new EntityButton("QUIT");
            this.quitButton.ESprite.X = Misc.WindowWidth / 2 - this.quitButton.ESprite.Width / 2;
            this.quitButton.ESprite.Y = Misc.WindowHeight / 2 + this.quitButton.ESprite.Width / 2;

            this.madeFor = new Text("Made by MatKubik for Ludum Dare 39", "ButtonFont", Misc.WindowWidth / 2, Misc.WindowHeight - 25);
            this.madeFor.TextColor = Color.Orange;
        }

        // METHODS

        // GAME METHODS
        public void Update(GameTime gameTime, Input input)
        {
            this.startButton.Update(gameTime, input);
            this.quitButton.Update(gameTime, input);

            this.head1.Update(gameTime, input);
            this.head2.Update(gameTime, input);

            this.head1.ESprite.Rotation += -0.04f;
            this.head2.ESprite.Rotation += 0.04f;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.background.Draw(spriteBatch);
            this.title.Draw(spriteBatch);
            this.startButton.Draw(spriteBatch);
            this.quitButton.Draw(spriteBatch);
            this.madeFor.Draw(spriteBatch);
            this.head1.Draw(spriteBatch);
            this.head2.Draw(spriteBatch);
        }
    }
}
