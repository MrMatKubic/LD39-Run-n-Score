using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD39.Utils
{
    public enum MenuState
    {
        GAME,
        HOME,
        GO,
        PAUSE,
        QUIT
    };

    public enum SpriteType
    {
        BLOCKS,
        ENEMIES,
        PLAYER,
        ITEM,
        BUTTONS,
        TEXTS,
        HOME_BG
    };

    public enum Direction
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,
        NONE
    };
}
