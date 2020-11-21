using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftColorSimilar
{
    public class ColorBlock
    {
        public long HexColor { get; private set; }
        public string Name { get; private set; }

        public ColorBlock(long hexColor, string name)
        {
            HexColor = hexColor;
            Name = name;
        }
    }
}
