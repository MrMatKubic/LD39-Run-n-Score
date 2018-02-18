using LD39.Interfaces;
using LD39.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LD39.Interfaces;
using LD39.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD39.Global
{
    public class Sprite : IGUpdatable, IGDrawable
    {
        // FIELDS
        protected Rectangle destination;
        protected Texture2D texture;

        private Color spriteColor;
        public string img;
        protected int fade;

        // CONSTRUCTORS
        public Sprite(string img)
        {
            this.img = img;
            this.fade = 0;
            this.texture = Resources.Textures[img];
            this.destination = new Rectangle(0, 0, this.texture.Width, this.texture.Height);
            this.spriteColor = Color.White;
        }

        public Sprite(string img, int x, int y, int width, int height)
            : this(img, 1, x, y)
        {
            this.destination.Width = width;
            this.destination.Height = height;
        }

        public Sprite(string img, int ratio, bool reduce)
            : this(img)
        {
            if(!reduce)
            {
                this.destination.Width = this.texture.Width * ratio;
                this.destination.Height = this.texture.Height * ratio;
            }
            else
            {
                this.destination.Width = this.texture.Width / ratio;
                this.destination.Height = this.texture.Height / ratio;
            }
        }

        public Sprite(string img, int ratio, int x, int y)
            : this(img, ratio, false)
        {
            this.X = x;
            this.Y = y;
        }

        // PROPERTIES
        public Point Middle() { return new Point(this.X + this.Width / 2, this.Y + this.Height / 2); }
        public Rectangle Destination { get { return this.destination; } set { this.destination = value; } }
        public int X { get { return this.destination.X; } set { this.destination.X = value; } }
        public int Y { get { return this.destination.Y; } set { this.destination.Y = value; } }
        public Color SpriteColor { get { return this.spriteColor; } set { this.spriteColor = value; } }
        public Texture2D SpriteTexture { get { return this.texture; } }

        public string SpriteTextureName { get { return this.img; } }
        public int Width { get { return this.destination.Width; } set { this.destination.Width = value; } }
        public int Height { get { return this.destination.Height; } set { this.destination.Height = value; } }

        public void SetDestination(int x, int y)
        {
            this.destination.X = x;
            this.destination.Y = y;
        }

        // METHODS

        // GAME METHODS

        public virtual void Update(GameTime gameTime, Input input)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            
            /*this.fade += 1;
            if(this.fade > 255)
                this.fade = 255;*/
            spriteBatch.Draw(this.texture, this.destination, this.spriteColor);
        }
    }
}
