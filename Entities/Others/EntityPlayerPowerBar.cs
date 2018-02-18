using LD39.Global;
using LD39.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD39.Entities.Others
{
    public class EntityPlayerPowerBar : EntitySprite
    {
        // FIELDS
        private EntityAnimatedSprite movingBar;
        private int oldWidth;
        private int playerBasePower;
        private int playerPower;
        private Text yourPower;

        // CONSTRUCTORS
        public EntityPlayerPowerBar(int playerBasePower)
            : base(new Sprite("playerPB", 4, false))
        {
            this.ESprite.X = Misc.WindowWidth / 2 - this.ESprite.Width / 2;
            this.ESprite.Y = 20;

            this.movingBar = new EntityAnimatedSprite(new AnimatedSprite("playerPBM", 1, 1, 4, 1, 1));
            this.movingBar.ESprite.X = Misc.WindowWidth / 2 - this.ESprite.Width / 2 + 4;
            this.movingBar.ESprite.Y = 24;
            this.oldWidth = this.movingBar.ESprite.Width;

            this.playerBasePower = playerBasePower;
            this.yourPower = new Text("POWER BAR", "ButtonFont", Misc.WindowWidth / 2, this.movingBar.ESprite.Y + this.movingBar.ESprite.Height * 4);
            this.yourPower.TextColor = Color.SkyBlue;
        }

        // METHODS
        public int PlayerPower { get { return this.playerPower; } set { this.playerPower = value; } }
        public int PlayerPowerEvol { get { return this.movingBar.ESprite.SpriteColor == Color.Green ? 1 : this.movingBar.ESprite.SpriteColor == Color.Orange ? 2 : 3; } set { this.PlayerPowerEvol = value; } }

        // GAME METHODS
        public override void Update(GameTime gameTime, Input input)
        {
            base.Update(gameTime, input);
            this.movingBar.Update(gameTime, input);

            this.movingBar.ESprite.Width = (int)(this.oldWidth * this.playerPower / this.playerBasePower);

            if(this.movingBar.ESprite.Width > 2 * (this.oldWidth / 3)) this.movingBar.ESprite.SpriteColor = Color.Green;
            if(this.movingBar.ESprite.Width > this.oldWidth / 3 && this.movingBar.ESprite.Width < 2 * (this.oldWidth / 3)) this.movingBar.ESprite.SpriteColor = Color.Orange;
            if(this.movingBar.ESprite.Width < this.oldWidth / 3) this.movingBar.ESprite.SpriteColor = Color.Red;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            this.movingBar.Draw(spriteBatch);
            this.yourPower.Draw(spriteBatch);
            base.Draw(spriteBatch);
        }
    }
}
