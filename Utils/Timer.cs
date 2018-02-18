using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD39.Utils
{
    public class Timer
    {
        // FIELDS
        private float minutes;
        private float seconds;

        private Text timer;

        private int baseX;
        private int baseY;

        // CONSTRUCTORS
        public Timer(int x, int y)
        {
            this.minutes = 0f;
            this.seconds = 0f;
            this.timer = new Text(this.minutes + " :  " + (int)this.seconds, "timerFont", x, y);
            this.timer.TextColor = Color.White;

            this.baseX = x + 5;
            this.baseY = y;
        }

        // METHODS
        public Text TimerText { get { return this.timer; } set { this.timer = value; } }

        // GAME METHODS
        public void Update(GameTime gameTime)
        {
            this.seconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
            this.minutes += (float)gameTime.ElapsedGameTime.TotalMinutes;

            if(this.seconds >= 60)
                this.seconds = 0;

            this.timer.SpriteText = ((int)this.minutes).ToString() + ":" + (this.seconds < 10 ? "0" : "") + ((int)this.seconds).ToString();
            this.timer.SetCenterOrigin(this.baseX, this.baseY);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.timer.Draw(spriteBatch);
        }
    }
}
