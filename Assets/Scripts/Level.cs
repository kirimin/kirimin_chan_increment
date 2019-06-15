using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Level
{
    
    public static readonly List<int> levelRanges = new List<int> {
        0,
        100,
        500,
        1000
    };

    public static int getLevel(int size) {
        for (var i = levelRanges.Count - 1; i >= 0; i--) {
            if (levelRanges[i] <= size) {
                return i;
            }
        }
        Debug.Log("return 0");
        return 0;
    }
}
