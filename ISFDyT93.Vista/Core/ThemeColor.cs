using System;
using System.Collections.Generic;
using System.Drawing;

namespace ISFDyT93.Vista.Core
{
    public class ThemeColor
    {
        public Color Primary { get; set; }
        public Color Secondary { get; set; }

        public int Index { get; set; }

        public List<string> ColorList { get; set; }

        public Random Random { get; set; }

        private static ThemeColor Context { get; set; }

        public ThemeColor()
        {
            this.ColorList = new List<string>() {
                    "#3F51B5",
                    "#009688",
                    "#FF5722",
                    "#607D8B",
                    "#FF9800",
                    "#9C27B0",
                    "#2196F3",
                    "#EA676C",
                    "#E41A4A",
                    "#5978BB",
                    "#018790",
                    "#0E3441",
                    "#00B0AD",
                    "#721D47",
                    "#EA4833",
                    "#EF937E",
                    "#F37521",
                    "#A12059",
                    "#126881",
                    "#8BC240",
                    "#364D5B",
                    "#C7DC5B",
                    "#0094BC",
                    "#E4126B",
                    "#43B76E",
                    "#7BCFE9",
                    "#B71C46"
                };

            this.Random = new Random();

            this.Primary = Color.FromArgb(51, 51, 76);
            this.Secondary = Color.FromArgb(39, 39, 58);
        }

        public static Color GetColor()
        {
            var context = GetTheme();

            int index = context.Random.Next(Context.ColorList.Count);

            while(Context.Index == index)
            {
                index = context.Random.Next(Context.ColorList.Count);
            }

            context.Index = index;

            string color = context.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        public static ThemeColor GetTheme()
        {
            if (Context == null)
            {
                Context = new ThemeColor();
            }

            return Context;
        }
    }
}
