using LD39.Entities;
using LD39.Global;
using LD39.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD39.Menus
{
    public class MenuGO
    {
        // FIELDS
        private EntitySprite background;
        private EntitySprite scorePanel;

        private EntityButton homeButton;

        private Text grayBarrelNumber;
        private Text redBarrelNumber;
        private Text blueBBarrelNumber;
        private Text questionBarrelNumber;
        private Text t1;
        private Text t2;
        private Text youDied;
        private Text stats;

        // CONSTRUCTORS
        public MenuGO()
        {
            this.background = new EntitySprite(new Sprite("gobackground", 4, false));
            this.scorePanel = new EntitySprite(new Sprite("scorePanel", 3, false));
            this.scorePanel.ESprite.X = Misc.WindowWidth / 2 - this.scorePanel.ESprite.Width / 2;
            this.scorePanel.ESprite.Y = 90;

            this.homeButton = new EntityButton("HOME");
            this.homeButton.ESprite.X = Misc.WindowWidth / 2 - this.homeButton.ESprite.Width / 2;
            this.homeButton.ESprite.Y = Misc.WindowHeight / 2 + this.homeButton.ESprite.Height * 2;

            this.grayBarrelNumber = new Text("x" + Misc.grayBarrelGet, "ButtonFont", this.scorePanel.ESprite.X + 17 * 3, this.scorePanel.ESprite.Y + 21 * 3);
            this.grayBarrelNumber.TextColor = Color.DarkGray;
            this.blueBBarrelNumber = new Text("x" + Misc.blueBarrelGet, "ButtonFont", this.scorePanel.ESprite.X + 55 * 3, this.scorePanel.ESprite.Y + 21 * 3);
            this.blueBBarrelNumber.TextColor = Color.DarkBlue;
            this.redBarrelNumber = new Text("x" + Misc.redBarrelGet, "ButtonFont", this.scorePanel.ESprite.X + 93 * 3, this.scorePanel.ESprite.Y + 21 * 3);
            this.redBarrelNumber.TextColor = Color.DarkRed;
            this.questionBarrelNumber = new Text("x" + Misc.questionBarrelGet, "ButtonFont", this.scorePanel.ESprite.X + 131 * 3, this.scorePanel.ESprite.Y + 21 * 3);

            this.t1 = new Text("TIME :", "ButtonFont", this.scorePanel.ESprite.X + 176 * 3, this.scorePanel.ESprite.Y + 6 * 3);
            this.t2 = new Text(Misc.playTimer, "ButtonFont", this.scorePanel.ESprite.X + 175 * 3, this.scorePanel.ESprite.Y + 21 * 3);
            this.t1.TextColor = Color.DarkGreen;
            this.t2.TextColor = Color.LightGray;
            this.youDied = new Text("YOU DIDN'T HAVE ENOUGH POWER TO SURVIVE!", "timerFont", Misc.WindowWidth / 2, Misc.WindowHeight / 2);
            this.youDied.TextColor = Color.Red;
            this.stats = new Text("YOUR STATS", "ButtonFont", Misc.WindowWidth / 2, Misc.WindowHeight / 2 - 75);
            this.stats.TextColor = Color.Yellow;
        }


        // METHODS

        // GAME METHODS
        public void Update(GameTime gameTime, Input input)
        {
            this.homeButton.Update(gameTime, input);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.background.Draw(spriteBatch);
            this.scorePanel.Draw(spriteBatch);
            this.homeButton.Draw(spriteBatch);
            this.grayBarrelNumber.Draw(spriteBatch);
            this.blueBBarrelNumber.Draw(spriteBatch);
            this.redBarrelNumber.Draw(spriteBatch);
            this.questionBarrelNumber.Draw(spriteBatch);
            this.t1.Draw(spriteBatch);
            this.t2.Draw(spriteBatch);
            this.youDied.Draw(spriteBatch);
            this.stats.Draw(spriteBatch);
        }
    }
}
