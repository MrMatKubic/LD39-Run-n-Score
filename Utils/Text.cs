using LD39.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD39.Utils
{
    public class Text
    {
        // FIELDS
        private string text;
        private Vector2 textPosition;
        private Vector2 textSize;
        private Color textColor;
        private SpriteFont font;

        // CONSTRUCTORS
        public Text(string text, string fontName) 
        {
            this.text = text;
            this.textColor = Color.White;
            this.font = Resources.Fonts[fontName];
            this.textSize = this.font.MeasureString(this.text);
        }
        
        public Text(string text, string fontName, float x, float y)
        {
            this.text = text;
            this.textColor = Color.White;
            this.font = Resources.Fonts[fontName];
            this.textSize = this.font.MeasureString(this.text);
            this.textPosition = new Vector2(x - this.textSize.X / 2, y - this.textSize.Y / 2);
        }

        // METHODS
        public void SetLDOrigin(int x, int y)
        {
            this.textSize = this.font.MeasureString(this.text);
            this.textPosition = new Vector2(x, y - this.textSize.Y);
        }

        public void SetCenterOrigin(int x, int y)
        {
            this.textSize = this.font.MeasureString(this.text);
            this.textPosition = new Vector2(x - this.textSize.X / 2, y - this.textSize.Y / 2);
        }

        public Vector2 TextSize { get { return this.textSize; } }
        public Color TextColor { get { return this.textColor; } set { this.textColor = value; } }
        public byte ColorR { get { return this.textColor.R; } set { this.textColor.R = value; } }
        public byte ColorG { get { return this.textColor.G; } set { this.textColor.G = value; } }
        public byte ColorB { get { return this.textColor.B; } set { this.textColor.B = value; } }
        public byte ColorA { get { return this.textColor.A; } set { this.textColor.A = value; } }

        public float X { get { return this.textPosition.X; } set { this.textPosition.X = value; } }
        public float Y { get { return this.textPosition.Y; } set { this.textPosition.Y = value; } }

        public string SpriteText { get { return this.text; } set { this.text = value; } }

        // GAME METHODS
        public void Update(GameTime gameTime, Input input)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(this.font, this.text, this.textPosition, this.textColor);
        }
    }
}
