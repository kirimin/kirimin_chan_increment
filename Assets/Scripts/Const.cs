using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Const 
{
    public static class ItemConst
    {
        private static readonly string ONE = "One";
        private static readonly string ZERO = "Zero";
        private static readonly string PIXEL = "Pixel";        
        private static readonly string MI = "Mi";

        public static readonly List<List<string>> ItemLevels = new List<List<string>>
        {
            new List<string> {
                ONE, ONE, ONE, ONE, ONE, ONE, ZERO, ZERO, ZERO, ZERO, ZERO, ZERO, PIXEL, PIXEL, MI
            }
        };
    }

    public static class ColorConst {

        public static readonly Color RED = new Color(0.80f, 0.20f, 0.40f, 1f);
        public static readonly Color BLUE = new Color(0.20f, 0.20f, 0.60f, 1);
    }
}
