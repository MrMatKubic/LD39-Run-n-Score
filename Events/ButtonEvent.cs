using LD39.Entities;
using LD39.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD39.Events
{
    public class ButtonEvent
    {
        // FIELDS
        private EntityButton button;

        // CONSTRUCTORS
        public ButtonEvent(EntityButton button)
        {
            this.button = button;
        }

        // METHODS
        public void Activate() 
        {
            if(this.button.Text.SpriteText == "QUIT")
                MenuManager.ChangeMenu(MenuState.QUIT);
            if(this.button.Text.SpriteText == "PLAY")
                MenuManager.ChangeMenu(MenuState.GAME);
            if(this.button.Text.SpriteText == "HOME")
                MenuManager.ChangeMenu(MenuState.HOME);
        }
    }
}
