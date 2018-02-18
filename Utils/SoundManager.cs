using LD39.Utils;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD39.Utils
{
    public class SoundManager
    {
        // FIELDS
        public static SoundEffect BUTTON_CLICK = Resources.Sounds["button"];
        public static SoundEffect PLAYER_JUMP = Resources.Sounds["jump"];
        public static SoundEffect RED_BARREL = Resources.Sounds["redBarrelhurt"];
        public static SoundEffect SCORE_BARREL = Resources.Sounds["scoreBarrel"];
        public static SoundEffect QUESTION_BARREL = Resources.Sounds["questionBarrel"];

        private static float vol = 1f;
        private static float pitch = 0f;
        private static float pan = 0f;

        // METHODS
        public static void PlaySound(SoundEffect effect) 
        {
            effect.Play(vol, pitch, pan);
        }
        
        public static void SetVolume(float volume) { vol = volume; }
        public static void SetPitch(float p) { pitch = p; }
        public static void SetPan(float p) { pan = p; }

    }
}
