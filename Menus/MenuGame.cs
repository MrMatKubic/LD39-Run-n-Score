using LD39.Entities;
using LD39.Global;
using LD39.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD39.Menus
{
    public class MenuGame
    {
        // OBJECTS
        private EntitySprite background;
        private EntitySprite ground;
        private EntitySprite ground1;
        
        private EntityAnimatedSprite timerPanel;
        private Timer playTimer;

        private EntityPlayer player;


        // OBJECT GROUPS
        private List<EntityBarrel> barrels;

        // VARIABLES
        private int groundSpeed;
        private Random rand;
        private float timer;
        private int randPlatSpawnTime;
        private int playerFloorCollsPos;
        private float speedPlusTimer;

        // CONSTRUCTORS
        public MenuGame()
        {
            Misc.blueBarrelGet = 0;
            Misc.redBarrelGet = 0;
            Misc.grayBarrelGet = 0;
            Misc.questionBarrelGet = 0;
            Misc.playTimer = "";

            this.speedPlusTimer = 0f;

            this.timerPanel = new EntityAnimatedSprite(new AnimatedSprite("uiPanel", 1, 1, 6, 1f, 1f));
            this.timerPanel.ESprite.Effect = SpriteEffects.FlipHorizontally;
            this.timerPanel.ESprite.X = Misc.WindowWidth - this.timerPanel.ESprite.Width;

            this.playTimer = new Timer(this.timerPanel.ESprite.X + this.timerPanel.ESprite.Width / 2, this.timerPanel.ESprite.Y + this.timerPanel.ESprite.Height / 2);

            this.barrels = new List<EntityBarrel>();

            this.randPlatSpawnTime = 0;
            this.timer = 0f;
            this.rand = new Random();

            this.groundSpeed = 6;
            this.background = new EntitySprite(new Sprite("background", 4, false));
            
            this.ground = new EntitySprite(new Sprite("ground", 4, false));
            this.ground.ESprite.Y = Misc.WindowHeight - this.ground.ESprite.Height;
         
            this.ground1 = new EntitySprite(new Sprite("ground", 4, false));
            this.ground1.ESprite.Y = Misc.WindowHeight - this.ground1.ESprite.Height;
            this.ground1.ESprite.X = Misc.WindowWidth;

            this.player = new EntityPlayer(this.ground.ESprite.Y);
            this.player.ESprite.Y = this.ground.ESprite.Y - this.player.ESprite.Height;
            this.randPlatSpawnTime = rand.Next(2000, 5000);
            this.playerFloorCollsPos = this.ground.ESprite.Y;
        }

        // METHODS
        private void ResetGroundsPos()
        {
            this.ground.ESprite.X = 0;
            this.ground1.ESprite.X = Misc.WindowWidth;
        }

        // GAME METHODS
        public void Update(GameTime gameTime, Input input)
        {
            this.timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            this.speedPlusTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if(this.speedPlusTimer > 20000)
            {
                if(this.groundSpeed < 12) this.groundSpeed += 1;
                this.speedPlusTimer = 0f;
            }

            if(this.ground1.ESprite.X < 0)
            {
                this.ResetGroundsPos();
            }
            this.ground.ESprite.X -= this.groundSpeed;
            this.ground1.ESprite.X -= this.groundSpeed;
        
            // DEBUG THINGS
            if(input.IsKeyPressedOnce(Keys.F)) MenuManager.ChangeMenu(MenuState.HOME);
        
            // END DEBUG THINGS

            this.player.Update(gameTime, input);
            this.player.SetXSpeed(this.groundSpeed);

            if(this.player.ESprite.Y + this.player.CollsRect.Height >= this.playerFloorCollsPos)
            {
                this.player.FinishJump();
                this.player.ESprite.Y = this.playerFloorCollsPos - this.player.ESprite.Destination.Height;
            }

            if(this.timer > this.randPlatSpawnTime)
            {
                int randBarrel = rand.Next(1, 100);
                int barrelFrameX = 1;
                if(randBarrel < 15) barrelFrameX = 4;
                if(randBarrel >= 15 && randBarrel < 45) barrelFrameX = 2;
                if(randBarrel >= 45 && randBarrel < 75) barrelFrameX = 1;
                if(randBarrel >= 75) barrelFrameX = 3;

                this.barrels.Add(new EntityBarrel(this.ground.ESprite.Y, barrelFrameX, this.groundSpeed, rand.Next(1, 4)));
                this.rand = new Random();
                this.randPlatSpawnTime = rand.Next(750, 1500);
                this.timer = 0f;
            }

            for(int i = this.barrels.Count - 1; i >= 0; i--)
            {
                this.barrels[i].Update(gameTime, input);
                this.barrels[i].SetSpeed(this.groundSpeed);
                if(this.player.Sneak ? this.barrels[i].ESprite.Destination.Contains(this.player.Middle()) : this.barrels[i].ESprite.Destination.Contains(this.player.Middle()) || this.barrels[i].ESprite.Destination.Contains(this.player.RMCorner()) || this.barrels[i].ESprite.Destination.Contains(this.player.LMCorner()) || this.barrels[i].ESprite.Destination.Contains(this.player.BMCorner()) || this.barrels[i].ESprite.Destination.Contains(this.player.UMCorner()))
                {
                    SoundManager.SetVolume(0.4f);
                    switch(this.barrels[i].ESprite.FrameX)
                    {
                        case 1: this.player.AddPower(50); Misc.grayBarrelGet++; SoundManager.PlaySound(SoundManager.SCORE_BARREL); this.player.StartAuraAnim(1); break;
                        case 2: this.player.AddPower(150); Misc.blueBarrelGet++; SoundManager.PlaySound(SoundManager.SCORE_BARREL); this.player.StartAuraAnim(2);  break;
                        case 3: this.player.RemovePower(100); Misc.redBarrelGet++; SoundManager.PlaySound(SoundManager.RED_BARREL); this.player.StartAuraAnim(3); break;
                        case 4:
                            this.player.StartAuraAnim(4);
                            Misc.questionBarrelGet++;
                            SoundManager.PlaySound(SoundManager.QUESTION_BARREL);
                            if(rand.Next(0, 100) < 30)
                            {
                                this.player.AddPower(140);
                                this.rand = new Random();
                            }
                            else if(rand.Next(0, 100) > 30 && rand.Next(0, 100) < 50)
                            {
                                this.player.RemovePower(110);
                                this.rand = new Random();
                            }
                            else if(rand.Next(0, 100) > 60)
                            {
                                this.player.AddPower(250);
                                this.rand = new Random();
                            }
                            else if(rand.Next(0, 100) > 50 && rand.Next(0, 100) < 60)
                            {
                                this.player.RemovePower(220);
                                this.rand = new Random();
                            }
                            else
                            {
                                this.player.Power = 1000;
                                // TODO : DO ANYTHING ELSE TROLLY
                            }
                        break;
                        default: break;
                    }
                    this.barrels.RemoveAt(i);
                }
            }

            this.playTimer.Update(gameTime);

            this.player.RemovePower(1); // PLAYER MAIN MECHANISM
            if(this.player.Power < 0)
            {
                Misc.playTimer = this.playTimer.TimerText.SpriteText;
                MenuManager.ChangeMenu(MenuState.GO);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.background.Draw(spriteBatch);
            this.ground.Draw(spriteBatch);
            this.ground1.Draw(spriteBatch);

            this.player.Draw(spriteBatch);

            for(int i = this.barrels.Count - 1; i >= 0; i--)
            {
                this.barrels[i].Draw(spriteBatch);
            }

            this.timerPanel.Draw(spriteBatch);
            this.playTimer.Draw(spriteBatch);
        }
    }
}
