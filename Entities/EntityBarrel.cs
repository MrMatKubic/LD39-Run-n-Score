using LD39.Global;
using LD39.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD39.Entities
{
    public class EntityBarrel : EntityAnimatedSprite
    {
        // FIELDS
        private int groundSpeed;

        // CONSTRUCTORS
        public EntityBarrel(int baseY, int frameX, int groundSpeed, int heightLevel)
            : base(new AnimatedSprite("barrels", 1, 4, 4, (float)frameX, 1))
        {
            this.ESprite.Y = baseY - heightLevel * this.ESprite.Height;
            this.ESprite.X = Misc.WindowWidth;
            this.groundSpeed = groundSpeed;
        }

        // METHODS
        public void SetSpeed(int groundSpeed) { this.groundSpeed = groundSpeed; }

        // GAME METHODS
        public override void Update(GameTime gameTime, Input input)
        {
            base.Update(gameTime, input);
            this.ESprite.X -= this.groundSpeed;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
