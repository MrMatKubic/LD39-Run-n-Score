using LD39.Menus;
using LD39.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD39
{
    public class MenuManager
    {
        // FIELDS
        public static MenuState menuState;

        // MENUS
        private MenuGame menuGame;
        private MenuHome menuHome;
        private MenuGO menuGO;

        // CONSTRUCTORS
        public MenuManager() { menuState = MenuState.HOME; }
        public MenuManager(MenuState ms)
        {
            menuState = ms;
            this.menuGame = new MenuGame();
            this.menuHome = new MenuHome();
            this.menuGO = new MenuGO();
        }

        // METHODS
        public static void ChangeMenu(MenuState ms)
        {
            menuState = ms;
        }

        // GAME METHODS
        public void Update(GameTime gameTime, Input input)
        {
            switch(menuState)
            {
                case MenuState.HOME:
                    this.menuHome.Update(gameTime, input);
                    this.menuGame = new MenuGame();
                break;
                case MenuState.GAME:
                    this.menuGame.Update(gameTime, input);
                    this.menuHome = new MenuHome();
                    this.menuGO = new MenuGO();    
                break;
                case MenuState.GO:
                    this.menuGO.Update(gameTime, input);
                    this.menuHome = new MenuHome();
                break;
                default:

                break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(menuState.Equals(MenuState.HOME))
                this.menuHome.Draw(spriteBatch);
            if(menuState.Equals(MenuState.GAME))
                this.menuGame.Draw(spriteBatch);
            if(menuState.Equals(MenuState.GO))
                this.menuGO.Draw(spriteBatch);
        }
    }
}
