using LD39.Global;
using LD39.Interfaces;
using LD39.Utils;
using MFGJS2017.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD39.Entities
{
    public class EntitySprite : IGSpriteSign
    {
        // FIELDS
        protected Sprite sprite;
        private bool updated;

        // CONSTRUCTORS
        public EntitySprite(Sprite sprite)
        {
            this.sprite = sprite;
            this.updated = true;
        }

        // PROPERTIES
        public Sprite ESprite { get { return this.sprite; } set { this.sprite = value; } }
        public string SpriteTextureName { get { return this.sprite.SpriteTextureName; } }
        public bool Updated { get { return this.updated; } set { this.updated = value; } }


        public Point ULCorner() { return new Point(this.ESprite.Destination.X, this.ESprite.Destination.Y); } // UP LEFT
        public Point URCorner() { return new Point(this.ESprite.Destination.X + this.ESprite.Destination.Width, this.ESprite.Destination.Y); } // UP RIGHT
        public Point BLCorner() { return new Point(this.ESprite.Destination.X, this.ESprite.Destination.Y + this.ESprite.Destination.Height); } // BOTTOM LEFT
        public Point BRCorner() { return new Point(this.ESprite.Destination.X + this.ESprite.Destination.Width, this.ESprite.Destination.Y + this.ESprite.Destination.Height); } // BOTTOM RIGHT
        public Point UMCorner() { return new Point(this.ESprite.Destination.X + this.ESprite.Destination.Width / 2, this.ESprite.Destination.Y); } // UP MIDDLE
        public Point BMCorner() { return new Point(this.ESprite.Destination.X + this.ESprite.Destination.Width / 2, this.ESprite.Destination.Y + this.ESprite.Destination.Height); } // BOTTOM MIDDLE
        public Point RMCorner() { return new Point(this.ESprite.Destination.X + this.ESprite.Destination.Width, this.ESprite.Destination.Y + this.ESprite.Destination.Height / 2); } // RIGHT MIDDLE
        public Point LMCorner() { return new Point(this.ESprite.Destination.X, this.ESprite.Destination.Y + this.ESprite.Destination.Height / 2); } // LEFT MIDDLE
        public Point Middle() { return new Point(this.ESprite.Destination.X + (this.ESprite.Destination.Width / 2), this.ESprite.Destination.Y + (this.ESprite.Destination.Height / 2)); }


        // METHODS
        public bool CollideWith(EntitySprite oSprite) { return this.sprite.Destination.Contains(oSprite.ESprite.Middle()); }

        // GAME METHODS
        public virtual void Update(GameTime gameTime, Input input)
        {
            this.sprite.Update(gameTime, input);
            //this.sprite.ESprite.Destination = new Rectangle(this.ESprite.X, this.ESprite.Y, this.sprite.Width, this.sprite.Height);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            this.sprite.Draw(spriteBatch);
        }
    }
}
