using System.Collections.Generic;

public static class Level
{
    
    public static readonly List<int> levelRanges = new List<int> {
        0,
        100,
        1000,
        5000
    };

    public static int getLevel(int size) {
        for (var i = levelRanges.Count - 1; i >= 0; i--) {
            if (levelRanges[i] <= size) {
                return i;
            }
        }
        return 0;
    }

    public static int GetNext(int level) {
        return levelRanges[level + 1];
    }
}
