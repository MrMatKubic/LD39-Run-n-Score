using LD39.Events;
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
    public class EntityButton : EntityAnimatedSprite
    {
        // FIELDS
        private Text text;
        private string t;
        private ButtonEvent BEvent;
        protected bool isPressed; // ONLY FOR INHERITED CLASSES

        // CONSTRUCTORS
        public EntityButton(string text)
            : base(new AnimatedSprite("buttonShape"/*<- add there button shape texture name*/, 2, 1, 4))
        {
            this.isPressed = false;
            this.t = text;
            this.BEvent = new ButtonEvent(this);
            this.text = new Text(text, "ButtonFont", this.ESprite.X + this.ESprite.Width / 2, this.ESprite.Y + this.ESprite.Height / 2 - 5);
        }

        // METHODS
        public Text Text { get { return this.text; } }
        public string Textt { get { return this.t; } set { this.t = value; } }

        // GAME METHODS
        public override void Update(GameTime gameTime, Input input)
        {
            base.Update(gameTime, input);

            this.text.Update(gameTime, input);
            this.text = new Text(this.t, "ButtonFont", this.ESprite.X + this.ESprite.Width / 2, this.ESprite.Y + this.ESprite.Height / 2);
            Point MousePos = new Point(input.GetMouseX(), input.GetMouseY());
            
            if(this.ESprite.Destination.Contains(MousePos))
            {
                this.ESprite.FrameY = 2;
                this.text.TextColor = Color.Gray;
                if(input.IsLeftMousePressed())
                {
                    SoundManager.SetVolume(1f);
                    SoundManager.PlaySound(SoundManager.BUTTON_CLICK);
                    this.isPressed = true;
                    this.BEvent.Activate();
                }
                else
                {
                    this.isPressed = false;
                }
            }
            
            else
            {
                this.ESprite.FrameY = 1;
                this.text.TextColor = Color.White;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            this.text.Draw(spriteBatch);
        }
    }
}
