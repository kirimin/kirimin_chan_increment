using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Const 
{
    public static class ItemConst
    {
        private static readonly string ONE = "One";
        private static readonly string ZERO = "Zero";
        private static readonly string ONE_ONE = "OneOne";
        private static readonly string ONE_ZERO = "OneZero";
        private static readonly string PIXEL = "Pixel";
        private static readonly string MI = "Mi";
        private static readonly string NN = "Nn";
        private static readonly string VOID_START = "voidStart";
        private static readonly string VOID_UPDATE = "voidUpdate";

        public static readonly List<List<string>> ItemLevels = new List<List<string>>
        {
            new List<string> {
                ONE, ONE, ONE, ONE, ONE, ONE, ONE, ONE, ONE,
                ZERO, ZERO, ZERO, ZERO, ZERO, ZERO, ZERO, ZERO, ZERO,
                ONE_ONE, ONE_ONE,
                ONE_ZERO, ONE_ZERO,
                PIXEL, PIXEL,
                MI, NN
            },
            new List<string> {
                ZERO,
                ONE, 
                ONE_ONE, ONE_ONE,
                ONE_ZERO, ONE_ZERO,
                PIXEL, PIXEL, PIXEL, PIXEL, PIXEL, PIXEL, PIXEL, PIXEL, 
                PIXEL, PIXEL, PIXEL, PIXEL, PIXEL, PIXEL, PIXEL, PIXEL,
                PIXEL, PIXEL, PIXEL, PIXEL, PIXEL, PIXEL, PIXEL, PIXEL,
                MI, MI, MI, MI, MI, NN, NN, NN, NN,
                VOID_START, VOID_UPDATE
            },
            new List<string> {
                
            } 
        };
    }

    public static class ColorConst {

        public static readonly Color RED = new Color(0.80f, 0.20f, 0.40f, 1f);
        public static readonly Color BLUE = new Color(0.20f, 0.20f, 0.60f, 1);
    }
}
