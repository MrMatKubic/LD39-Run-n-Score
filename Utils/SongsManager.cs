using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD39.Utils
{
    public class SongsManager
    {
        public SoundEffectInstance gameMusic;
        public SoundEffectInstance homeMusic;

        public SongsManager()
        {
            this.homeMusic = Resources.Sounds["song3"].CreateInstance();
            this.gameMusic = Resources.Sounds["song2"].CreateInstance();
            this.gameMusic.Volume = 0.9f;
            this.gameMusic.Pitch = 0f;
            this.homeMusic.Volume = 0.9f;
            this.homeMusic.Pitch = 0f;
        }

        public void Update(GameTime gameTime)
        {
            if(MenuManager.menuState == MenuState.GAME)
            {
                this.homeMusic.Stop();

                this.gameMusic.IsLooped = true;
                this.gameMusic.Play();
            }
            else if(MenuManager.menuState == MenuState.HOME || MenuManager.menuState == MenuState.GO)
            {
                this.gameMusic.Stop();

                this.homeMusic.IsLooped = true;
                this.homeMusic.Play();
            }
            else
            {
                this.gameMusic.Stop();
                this.homeMusic.Stop();
            }
        }
    }
}
