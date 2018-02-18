using LD39.Utils;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD39.Interfaces
{
    public interface IGUpdatable
    {
        void Update(GameTime gameTime, Input input);
    }
}
