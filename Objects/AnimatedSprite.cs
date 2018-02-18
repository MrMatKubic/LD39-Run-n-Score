using LD39.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD39.Global
{
    public class AnimatedSprite : Sprite
    {
        // FIELDS
        private Rectangle source;
        
        private int rows;
        private int columns;

        private int currentX;
        private int currentY;
        
        private int sourcePosX;
        private int sourcePosY;
        private int DesWidth;
        private int DesHeight;

        private Vector2 origin;
        private float rotation;
        private float angle;
        private SpriteEffects effect;
        private float timer;

        // CONSTRUCTORS
        public AnimatedSprite(string img, int rows, int columns)
            : base(img)
        {            
            this.columns = columns;
            this.rows = rows;
            
            this.currentX = 1;
            this.currentY = 1;
            
            this.effect = SpriteEffects.None;
            this.angle = 0;
            this.rotation = 0f;

            this.sourcePosX = (this.currentX - 1) * this.destination.Width;
            this.sourcePosY = (this.currentY - 1) * this.destination.Height;

            this.DesWidth = this.texture.Width / this.columns;
            this.DesHeight = this.texture.Height / this.rows;

            this.SpriteColor = Color.White;

            this.destination = new Rectangle(0, 0, this.DesWidth, this.DesHeight);
            this.source = new Rectangle(this.sourcePosX, this.sourcePosY, this.DesWidth, this.DesHeight);
            this.origin = Vector2.Zero;
        }

        public AnimatedSprite(string img, int rows, int columns, int ratio)
            : this(img, rows, columns)
        {
            this.destination = new Rectangle(0, 0, this.DesWidth * ratio, this.DesHeight * ratio);
        }

        public AnimatedSprite(string img, int rows, int columns, int ratio, float frameX, float frameY)
            : this(img, rows, columns, ratio)
        {
            this.currentX = (int)frameX;
            this.currentY = (int)frameY;
        }

        public AnimatedSprite(string img, int rows, int columns, int ratio, int x, int y)
            : this(img, rows, columns, ratio)
        {
            this.X = x;
            this.Y = y;
        }

        // PROPERTIES
        public float Angle { get { return this.angle; } set { this.angle = value; } }
        public Vector2 Origin { get { return this.origin; } set { this.origin = value; } }
        public SpriteEffects Effect { get { return this.effect; } set { this.effect = value; } }
        public new Point Middle() { return new Point(this.X + this.Width / 2, this.Y + this.Height / 2); }
        public float Rotation { get { return this.rotation; } set { this.rotation = value; } }

        public int FrameX { get { return this.currentX; } set { this.currentX = value; } }
        public int FrameY { get { return this.currentY; } set { this.currentY = value; } }

        public int Rows { get { return this.rows; } }
        public int Columns { get { return this.columns; } }
        
        public new int X { get { return this.destination.X; } set { this.destination.X = value; } }
        public new int Y { get { return this.destination.Y; } set { this.destination.Y = value; } }

        public int SourceWidth { get { return this.source.Width; } set { this.source.Width = value; } }
        public int SourceHeight { get { return this.source.Height; } set { this.source.Height = value; } }

        // METHODS
        public void AnimateX(float delay /*IN SECONDS !*/ )
        {
            if(this.timer > delay * 1000)
            {
                this.currentX++;
                if(this.currentX > this.columns)
                    this.currentX = 1;
                this.timer = 0f;
            }
        }

        public void AnimateY(float delay)
        {
            if(this.timer > delay * 1000)
            {
                this.currentY++;
                if(this.currentY > this.rows)
                    this.currentY = 1;
                this.timer = 0f;
            }
        }

        public void UpdateSourcePos()
        {
            this.sourcePosX = (this.currentX - 1) * this.DesWidth;
            this.sourcePosY = (this.currentY - 1) * this.DesHeight;

            this.source.X = this.sourcePosX;
            this.source.Y = this.sourcePosY;
        }

        // GAME METHODS
        public override void Update(GameTime gameTime, Input input)
        {
            base.Update(gameTime, input);
            this.timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            //this.rotation = 0f;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //base.Draw(spriteBatch);
            /*this.fade += 1;
            if(this.fade > 255)
                this.fade = 255;*/
            //Debug.WriteLine(this.fade);
            spriteBatch.Draw(this.texture, this.destination, this.source, this.SpriteColor, this.rotation, this.origin, this.effect, 0f);
        }
    }
}
