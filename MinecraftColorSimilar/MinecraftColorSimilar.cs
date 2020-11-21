using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices;

namespace MinecraftColorSimilar
{
    [ClassInterface(ClassInterfaceType.None)]
    public class MinecraftColorSimilar
    {
        #region 颜色定义
        static ColorBlock WhiteWool = new ColorBlock(0xE9ECEC, "white_wool");
        static ColorBlock OrangeWool = new ColorBlock(0xF07613, "orange_wool");
        static ColorBlock MagentaWool = new ColorBlock(0xB350BC, "magenta_wool");
        static ColorBlock LightBlueWool = new ColorBlock(0x6B8AC9, "light_blue_wool");
        static ColorBlock YellowWool = new ColorBlock(0xB1A627, "yellow_wool");
        static ColorBlock LimeWool = new ColorBlock(0x41AE38, "lime_wool");
        static ColorBlock PinkWool = new ColorBlock(0xED8DAC, "pink_wool");
        static ColorBlock GrayWool = new ColorBlock(0x3E4447, "gray_wool");
        static ColorBlock LightGrayWool = new ColorBlock(0x8E8E86, "light_gray_wool");
        static ColorBlock CyanWool = new ColorBlock(0x158991, "cyan_wool");
        static ColorBlock PurpleWool = new ColorBlock(0x792AAC, "purple_wool");
        static ColorBlock BlueWool = new ColorBlock(0x35399D, "blue_wool");
        static ColorBlock BrownWool = new ColorBlock(0x724728, "brown_wool");
        static ColorBlock GreenWool = new ColorBlock(0x546D1B, "green_wool");
        static ColorBlock RedWool = new ColorBlock(0xA12722, "red_wool");
        static ColorBlock BlackWool = new ColorBlock(0x141519, "black_wool");

        static List<ColorBlock> ColorBlocks = new List<ColorBlock>()
            {WhiteWool,OrangeWool,MagentaWool,LightBlueWool,YellowWool,LimeWool,
                PinkWool,GrayWool,LightGrayWool,CyanWool,PurpleWool,BlueWool,BrownWool,GreenWool,
                RedWool,BlackWool };
        #endregion

        /// <summary>
        /// 获取与所给颜色最接近的Minecraft方块名。
        /// </summary>
        /// <param name="red">红色。</param>
        /// <param name="green">绿色。</param>
        /// <param name="blue">蓝色。</param>
        /// <returns></returns>
        public string GetSimilarColorBlockName(uint red, uint green, uint blue)
        {
            if (!(red <= 255 && green <= 255 && blue <= 255))
            {
                throw new ArgumentException("提供的参数不符合要求。");
            }

            string _hex = ColorTranslator.ToHtml(Color.FromArgb((int)red, (int)green, (int)blue));
            _hex = "0x" + _hex.Substring(1);
            long hex =
                Convert.ToInt64(_hex, 16);

            Dictionary<ColorBlock, long> _difference = new Dictionary<ColorBlock, long>();//保存差
            foreach (ColorBlock c in ColorBlocks)//分别作差
            {
                _difference.Add(c, Math.Abs(c.HexColor - hex));//取绝对值
            }

            //升序排序
            var dicSorted = from objDic in _difference orderby objDic.Value select objDic;
            //dicSorted 类型为 KeyValuePair<ColorBlock,long>

            return dicSorted.First().Key.Name;
        }
    }
}
