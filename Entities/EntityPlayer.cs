using LD39.Entities.Others;
using LD39.Global;
using LD39.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD39.Entities
{
    public class EntityPlayer : EntityAnimatedSprite
    {
        // FIELDS
        private bool isJumping;
        private bool sneak;
        private float jumpVel;
        private float jumpVelIncre;
        private bool showMessage;

        private int power;
        private Vector2 moveSpeed;

        private EntityPlayerPowerBar powerBar;
        private Rectangle collsRect;
        private EntityAnimatedSprite hitAura;
        private float hitTimer;
        private bool takeDamage;
        private int takeDamageBarrel;

        private int groundY;
        private int groundSpeed;

        // CONSTRUCTORS
        public EntityPlayer(int groundY)
            : base(new AnimatedSprite("player", 2, 4, 3, 1f, 1f))
        {
            this.ESprite.X = Misc.WindowWidth / 2 - this.ESprite.Width / 2;
            this.takeDamageBarrel = 0;
            this.takeDamage = false;
            this.hitTimer = 0f;
            this.groundSpeed = 0;
            this.showMessage = false;
            this.sneak = false;
            this.groundY = groundY;
            this.moveSpeed = new Vector2(3, 15);
            this.jumpVel = -20f;
            this.jumpVelIncre = 0.8f;
            this.isJumping = false;
            this.power = 1000;
            this.powerBar = new EntityPlayerPowerBar(this.power);
            this.collsRect = new Rectangle(this.ESprite.X, this.ESprite.Y, this.ESprite.Width, this.ESprite.Height);
            this.hitAura = new EntityAnimatedSprite(new AnimatedSprite("playerHitAura", 2, 3, 3, 1f, 1f));
        }

        // PROPERTIES
        public int Power { get { return this.power; } set { this.power = value; } }
        public Rectangle CollsRect { get { return this.collsRect; } set { this.collsRect = value; } }
        public bool Sneak { get { return this.sneak; } set { this.sneak = value; } }
        public bool TakeDamage { get { return this.takeDamage; } set { this.takeDamage = value; } }

        // METHODS
        public void FinishJump()
        {
            this.jumpVel = -20f;
            this.isJumping = false;
        }

        public void AddPower(int added) { this.power += added; }
        public void RemovePower(int removed) { this.power -= removed; }

        public void SetXSpeed(int groundSpeed)
        {
            this.groundSpeed = groundSpeed;
        }

        public void StartAuraAnim(int barrelType)
        {
            this.takeDamage = true;
            this.takeDamageBarrel = barrelType;
        }

        // GAME METHODS
        public override void Update(GameTime gameTime, Input input)
        {
            base.Update(gameTime, input);
            this.ESprite.AnimateX(0.05f);
            
            if(this.power > 1000) this.power = 1000;
            if(this.power < 0) this.power = 0;

            this.powerBar.PlayerPower = this.power;
            this.powerBar.Update(gameTime, input);
            
            this.ESprite.X -= groundSpeed;

            if(input.IsKeyPressed(Keys.A) || input.IsKeyPressed(Keys.Left)) this.ESprite.X -= (int)this.moveSpeed.X;
            if(input.IsKeyPressed(Keys.D) || input.IsKeyPressed(Keys.Right)) this.ESprite.X += (int)this.moveSpeed.Y;

            this.collsRect.X = this.ESprite.X;
            this.collsRect.Y = this.ESprite.Y;

            if((input.IsKeyPressed(Keys.S) || input.IsKeyPressed(Keys.Down)) && !this.isJumping)
            {
                this.sneak = true;
                this.ESprite.FrameY = 2;
                this.collsRect.Height = this.ESprite.Height - 18 * 3;
                this.collsRect.Y = this.ESprite.Y + 18 * 3;
                this.ESprite.Y = this.groundY - this.CollsRect.Height;
            }
            else
            {
                this.sneak = false;
                this.ESprite.FrameY = 1;
                this.collsRect.Height = this.ESprite.Height;
                this.collsRect.Y = this.ESprite.Y;
            }

            if((input.IsKeyPressedOnce(Keys.Space) || input.IsKeyPressedOnce(Keys.Up)) && !this.isJumping && !this.sneak)
            {
                SoundManager.SetVolume(1f);
                SoundManager.PlaySound(SoundManager.PLAYER_JUMP);
            }

            if(this.takeDamage)
            {
                this.hitTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                switch(this.takeDamageBarrel)
                {
                    case 1: this.hitAura.ESprite.FrameX = 1; break;
                    case 2: this.hitAura.ESprite.FrameX = 1; break;
                    case 3: this.hitAura.ESprite.FrameX = 2; break;
                    case 4: this.hitAura.ESprite.FrameX = 3; break;
                }
                if(this.sneak) this.hitAura.ESprite.FrameY = 2; else this.hitAura.ESprite.FrameY = 1;
                if(this.hitTimer > 120)
                {
                    this.hitTimer = 0f;
                    this.takeDamage = false;
                }
            }
            else
            {
                this.hitAura.ESprite.FrameX = 1;
            }

            if((input.IsKeyPressedOnce(Keys.Space) || input.IsKeyPressedOnce(Keys.Up))&& !this.sneak)
            {
                this.isJumping = true;
            }
            
            if(this.isJumping)
            {
                this.ESprite.Y += (int)this.jumpVel;
                this.jumpVel += this.jumpVelIncre;
            }

            this.hitAura.Update(gameTime, input);
            this.hitAura.ESprite.X = this.sneak ? this.ESprite.X + 2 : this.ESprite.X;
            this.hitAura.ESprite.Y = this.sneak ? this.ESprite.Y - 60 : this.ESprite.Y - 3;

            switch(this.powerBar.PlayerPowerEvol)
            {
                case 1: this.jumpVelIncre = 0.6f; this.moveSpeed.Y = 17;  break;
                case 2: this.jumpVelIncre = 1f;   this.moveSpeed.Y = 13;  break;
                case 3: this.jumpVelIncre = 1.3f; this.moveSpeed.Y = 9;   break;
                default: break;
            }

            if(this.powerBar.PlayerPowerEvol == 3)
                this.showMessage = true;
            else
                this.showMessage = false;

            if(this.ESprite.X < 0)
            {
                //MenuManager.ChangeMenu(MenuState.GO);
                this.ESprite.X = 0;
                this.hitAura.ESprite.X = 3;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            if(this.takeDamage) this.hitAura.Draw(spriteBatch);
            this.powerBar.Draw(spriteBatch);
            //spriteBatch.Draw(Resources.Textures["viewHitbox"], this.collsRect, Color.White);
            if(this.showMessage)
            {
                Text running = new Text("YOU'RE RUNNING OUT OF POWER", "ButtonFont", Misc.WindowWidth / 2, Misc.WindowHeight - 40);
                running.TextColor = Color.Red;
                running.Draw(spriteBatch);
            }

        }
    }
}
