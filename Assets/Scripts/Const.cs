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
        private static readonly string TRIANGLE = "TRIANGLE";
        private static readonly string CIRCLE = "CIRCLE";
        private static readonly string MI = "Mi";
        private static readonly string NN = "Nn";
        private static readonly string VOID_START = "voidStart";
        private static readonly string VOID_UPDATE = "voidUpdate";
        private static readonly string BUG = "Bug";

        public static readonly List<List<string>> ItemLevels = new List<List<string>>
        {
            new List<string> {
                ONE, ONE, ONE, ONE, ONE, ONE, ONE, ONE, ONE,
                ZERO, ZERO, ZERO, ZERO, ZERO, ZERO, ZERO, ZERO, ZERO,
                ONE_ONE, ONE_ONE,
                ONE_ZERO, ONE_ZERO,
                PIXEL, 
                TRIANGLE,
                MI, NN
            },
            new List<string> {
                ZERO,
                ONE, 
                ONE_ONE, ONE_ONE,
                ONE_ZERO, ONE_ZERO,
                PIXEL, PIXEL, PIXEL, PIXEL, PIXEL, PIXEL, PIXEL, PIXEL, 
                TRIANGLE, TRIANGLE, TRIANGLE, TRIANGLE, TRIANGLE, TRIANGLE, TRIANGLE, TRIANGLE,
                CIRCLE, CIRCLE, CIRCLE, CIRCLE, CIRCLE, CIRCLE, CIRCLE, CIRCLE,
                MI, MI, MI, MI, MI, NN, NN, NN, NN,
                VOID_START, 
                VOID_UPDATE,
                BUG,
            },
            new List<string> {
                PIXEL, PIXEL, PIXEL, PIXEL,
                TRIANGLE, TRIANGLE, TRIANGLE,
                CIRCLE, CIRCLE, CIRCLE, CIRCLE,
                MI, MI, MI, MI, MI, NN, NN, NN, NN,
                VOID_START, VOID_START,
                VOID_UPDATE, VOID_START,
                BUG, BUG, BUG
            }
        };
    }

    public static class ColorConst {

        public static readonly Color RED = new Color(0.94f, 0.38f, 0.57f, 1f);
        public static readonly Color BLUE = Color.white; //new Color(0.25f,0.32f,0.71f);
    }
}
