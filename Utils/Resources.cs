using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD39.Utils
{
    public class Resources
    {
        public static Dictionary<string, Texture2D> Textures;
        public static Dictionary<string, SoundEffect> Sounds;
        public static Dictionary<string, SpriteFont> Fonts;

        public static void LoadResources(ContentManager content)
        {
            Textures = new Dictionary<string, Texture2D>();
            Sounds = new Dictionary<string, SoundEffect>();
            Fonts = new Dictionary<string, SpriteFont>();

            List<string> texs = new List<string>()
            {
                "background",
                "home_background",
                "columns",
                "ground",
                "pipes",
                "platform",
                "title",
                "buttonShape",
                "player",
                "barrels",
                "middle_platform",
                "playerPB",
                "playerPBM",
                "viewHitbox",
                "playerHead",
                "gobackground",
                "scorePanel",
                "uiPanel",
                "playerHitAura"
            };

            List<string> sfxs = new List<string>()
            {
                "button",
                "jump",
                "questionBarrel",
                "redBarrelhurt",
                "scoreBarrel",
                "song2",
                "song3"
            };

            List<string> fonts = new List<string>()
            {
                "ButtonFont",
                "timerFont"
            };

            foreach(string t in texs)
                Textures.Add(t, content.Load<Texture2D>("graphics/" + t));

            foreach(string s in sfxs)
                Sounds.Add(s, content.Load<SoundEffect>("sounds/" + s));

            foreach(string f in fonts)
                Fonts.Add(f, content.Load<SpriteFont>("fonts/" + f));


        }
    }
}
