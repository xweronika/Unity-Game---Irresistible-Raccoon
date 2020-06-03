using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelLayouts
{
    private static List<Vector3Int>[] layouts;

    static LevelLayouts()
    {
        layouts = new List<Vector3Int>[5];
        layouts[0] = new List<Vector3Int>();
        layouts[1] = new List<Vector3Int>();
        layouts[2] = new List<Vector3Int>();
        layouts[3] = new List<Vector3Int>();
        layouts[4] = new List<Vector3Int>();
        setLayouts();
    }

    private static void setLayouts()
    {
        layouts[1].Add(new Vector3Int(0, 8, 1));
        layouts[1].Add(new Vector3Int(1, 8, 0));
        layouts[1].Add(new Vector3Int(2, 8, 0));
        layouts[1].Add(new Vector3Int(3, 8, 0));
        layouts[1].Add(new Vector3Int(4, 8, 0));
        layouts[1].Add(new Vector3Int(5, 8, 0));
        layouts[1].Add(new Vector3Int(6, 8, 0));
        layouts[1].Add(new Vector3Int(7, 8, 1));
        layouts[1].Add(new Vector3Int(8, 8, 0));
        layouts[1].Add(new Vector3Int(9, 8, 0));
        layouts[1].Add(new Vector3Int(10, 8, 0));
        layouts[1].Add(new Vector3Int(11, 8, 0));
        layouts[1].Add(new Vector3Int(16, 8, 0));
        layouts[1].Add(new Vector3Int(17, 8, 0));
        layouts[1].Add(new Vector3Int(18, 8, 1));
        layouts[1].Add(new Vector3Int(19, 8, 0));
        layouts[1].Add(new Vector3Int(20, 8, 0));
        layouts[1].Add(new Vector3Int(21, 8, 0));
        layouts[1].Add(new Vector3Int(22, 8, 0));
        layouts[1].Add(new Vector3Int(23, 8, 1));
        layouts[1].Add(new Vector3Int(24, 8, 0));
        layouts[1].Add(new Vector3Int(25, 8, 0));
        layouts[1].Add(new Vector3Int(26, 8, 0));
        layouts[1].Add(new Vector3Int(5, 11, 0));
        layouts[1].Add(new Vector3Int(5, 12, 0));
        layouts[1].Add(new Vector3Int(5, 13, 1));
        layouts[1].Add(new Vector3Int(21, 11, 0));
        layouts[1].Add(new Vector3Int(21, 12, 0));
        layouts[1].Add(new Vector3Int(21, 13, 1));
        layouts[1].Add(new Vector3Int(5, 5, 0));
        layouts[1].Add(new Vector3Int(5, 4, 0));
        layouts[1].Add(new Vector3Int(5, 3, 1));
        layouts[1].Add(new Vector3Int(21, 5, 0));
        layouts[1].Add(new Vector3Int(21, 4, 0));
        layouts[1].Add(new Vector3Int(21, 3, 1));


        layouts[2].Add(new Vector3Int(4, 0, 0));
        layouts[2].Add(new Vector3Int(4, 1, 0));
        layouts[2].Add(new Vector3Int(4, 2, 0));
        layouts[2].Add(new Vector3Int(4, 3, 1));
        layouts[2].Add(new Vector3Int(4, 4, 0));
        layouts[2].Add(new Vector3Int(4, 5, 0));
        layouts[2].Add(new Vector3Int(4, 6, 0));
        layouts[2].Add(new Vector3Int(4, 7, 0));
        layouts[2].Add(new Vector3Int(4, 8, 1));
        layouts[2].Add(new Vector3Int(4, 9, 0));
        layouts[2].Add(new Vector3Int(4, 10, 0));
        layouts[2].Add(new Vector3Int(4, 11, 0));
        layouts[2].Add(new Vector3Int(4, 15, 0));
        layouts[2].Add(new Vector3Int(4, 16, 1));
        layouts[2].Add(new Vector3Int(4, 17, 0));
        layouts[2].Add(new Vector3Int(4, 18, 0));
        layouts[2].Add(new Vector3Int(9, 0, 0));
        layouts[2].Add(new Vector3Int(9, 1, 0));
        layouts[2].Add(new Vector3Int(9, 2, 0));
        layouts[2].Add(new Vector3Int(9, 3, 0));
        layouts[2].Add(new Vector3Int(9, 4, 0));
        layouts[2].Add(new Vector3Int(9, 5, 0));
        layouts[2].Add(new Vector3Int(9, 6, 1));
        layouts[2].Add(new Vector3Int(9, 7, 0));
        layouts[2].Add(new Vector3Int(9, 11, 0));
        layouts[2].Add(new Vector3Int(9, 12, 0));
        layouts[2].Add(new Vector3Int(9, 13, 0));
        layouts[2].Add(new Vector3Int(9, 14, 0));
        layouts[2].Add(new Vector3Int(9, 15, 0));
        layouts[2].Add(new Vector3Int(9, 16, 0));
        layouts[2].Add(new Vector3Int(9, 17, 0));
        layouts[2].Add(new Vector3Int(9, 18, 1));
        layouts[2].Add(new Vector3Int(17, 3, 0));
        layouts[2].Add(new Vector3Int(17, 4, 0));
        layouts[2].Add(new Vector3Int(17, 5, 0));
        layouts[2].Add(new Vector3Int(17, 6, 1));
        layouts[2].Add(new Vector3Int(17, 7, 0));
        layouts[2].Add(new Vector3Int(17, 8, 0));
        layouts[2].Add(new Vector3Int(17, 9, 0));
        layouts[2].Add(new Vector3Int(17, 10, 0));
        layouts[2].Add(new Vector3Int(17, 11, 0));
        layouts[2].Add(new Vector3Int(17, 12, 0));
        layouts[2].Add(new Vector3Int(17, 13, 0));
        layouts[2].Add(new Vector3Int(17, 14, 0));
        layouts[2].Add(new Vector3Int(17, 15, 0));
        layouts[2].Add(new Vector3Int(17, 16, 0));
        layouts[2].Add(new Vector3Int(17, 17, 0));
        layouts[2].Add(new Vector3Int(17, 18, 1));
        layouts[2].Add(new Vector3Int(22, 0, 0));
        layouts[2].Add(new Vector3Int(22, 1, 0));
        layouts[2].Add(new Vector3Int(22, 2, 0));
        layouts[2].Add(new Vector3Int(22, 3, 0));
        layouts[2].Add(new Vector3Int(22, 4, 0));
        layouts[2].Add(new Vector3Int(22, 5, 0));
        layouts[2].Add(new Vector3Int(22, 6, 1));
        layouts[2].Add(new Vector3Int(22, 7, 0));
        layouts[2].Add(new Vector3Int(22, 8, 0));
        layouts[2].Add(new Vector3Int(22, 9, 0));
        layouts[2].Add(new Vector3Int(22, 13, 0));
        layouts[2].Add(new Vector3Int(22, 14, 0));
        layouts[2].Add(new Vector3Int(22, 15, 0));
        layouts[2].Add(new Vector3Int(22, 16, 0));
        layouts[2].Add(new Vector3Int(22, 17, 0));
        layouts[2].Add(new Vector3Int(22, 18, 1));

        layouts[3].Add(new Vector3Int(4, 4, 0));
        layouts[3].Add(new Vector3Int(4, 5, 1));
        layouts[3].Add(new Vector3Int(4, 6, 0));
        layouts[3].Add(new Vector3Int(4, 7, 0));
        layouts[3].Add(new Vector3Int(4, 8, 1));
        layouts[3].Add(new Vector3Int(4, 9, 0));
        layouts[3].Add(new Vector3Int(4, 10, 0));
        layouts[3].Add(new Vector3Int(4, 11, 0));
        layouts[3].Add(new Vector3Int(4, 12, 0));
        layouts[3].Add(new Vector3Int(4, 13, 0));
        layouts[3].Add(new Vector3Int(4, 14, 1));
        layouts[3].Add(new Vector3Int(10, 4, 0));
        layouts[3].Add(new Vector3Int(10, 5, 0));
        layouts[3].Add(new Vector3Int(10, 6, 0));
        layouts[3].Add(new Vector3Int(10, 7, 0));
        layouts[3].Add(new Vector3Int(10, 8, 0));
        layouts[3].Add(new Vector3Int(10, 9, 0));
        layouts[3].Add(new Vector3Int(10, 10, 0));
        layouts[3].Add(new Vector3Int(10, 11, 0));
        layouts[3].Add(new Vector3Int(10, 12, 1));
        layouts[3].Add(new Vector3Int(10, 13, 0));
        layouts[3].Add(new Vector3Int(10, 14, 1));
        layouts[3].Add(new Vector3Int(16, 4, 0));
        layouts[3].Add(new Vector3Int(16, 5, 0));
        layouts[3].Add(new Vector3Int(16, 6, 0));
        layouts[3].Add(new Vector3Int(16, 7, 0));
        layouts[3].Add(new Vector3Int(16, 8, 0));
        layouts[3].Add(new Vector3Int(16, 9, 0));
        layouts[3].Add(new Vector3Int(16, 10, 0));
        layouts[3].Add(new Vector3Int(16, 11, 0));
        layouts[3].Add(new Vector3Int(16, 12, 1));
        layouts[3].Add(new Vector3Int(16, 13, 0));
        layouts[3].Add(new Vector3Int(16, 14, 0));
        layouts[3].Add(new Vector3Int(22, 4, 0));
        layouts[3].Add(new Vector3Int(22, 5, 0));
        layouts[3].Add(new Vector3Int(22, 6, 1));
        layouts[3].Add(new Vector3Int(22, 7, 0));
        layouts[3].Add(new Vector3Int(22, 8, 0));
        layouts[3].Add(new Vector3Int(22, 9, 0));
        layouts[3].Add(new Vector3Int(22, 10, 0));
        layouts[3].Add(new Vector3Int(22, 11, 0));
        layouts[3].Add(new Vector3Int(22, 12, 1));
        layouts[3].Add(new Vector3Int(22, 13, 0));
        layouts[3].Add(new Vector3Int(22, 14, 0));
        layouts[3].Add(new Vector3Int(5, 4, 1));
        layouts[3].Add(new Vector3Int(6, 4, 0));
        layouts[3].Add(new Vector3Int(7, 4, 0));
        layouts[3].Add(new Vector3Int(8, 4, 0));
        layouts[3].Add(new Vector3Int(9, 4, 0));
        layouts[3].Add(new Vector3Int(11, 14, 0));
        layouts[3].Add(new Vector3Int(12, 14, 0));
        layouts[3].Add(new Vector3Int(13, 14, 0));
        layouts[3].Add(new Vector3Int(14, 14, 0));
        layouts[3].Add(new Vector3Int(15, 14, 0));
        layouts[3].Add(new Vector3Int(17, 4, 1));
        layouts[3].Add(new Vector3Int(18, 4, 0));
        layouts[3].Add(new Vector3Int(19, 4, 0));
        layouts[3].Add(new Vector3Int(20, 4, 0));
        layouts[3].Add(new Vector3Int(21, 4, 0));

        layouts[4].Add(new Vector3Int(4, 0, 0));
        layouts[4].Add(new Vector3Int(4, 1, 0));
        layouts[4].Add(new Vector3Int(4, 2, 1));
        layouts[4].Add(new Vector3Int(4, 3, 0));
        layouts[4].Add(new Vector3Int(4, 4, 0));
        layouts[4].Add(new Vector3Int(4, 5, 0));
        layouts[4].Add(new Vector3Int(4, 6, 1));
        layouts[4].Add(new Vector3Int(4, 7, 0));

        layouts[4].Add(new Vector3Int(4, 11, 0));
        layouts[4].Add(new Vector3Int(4, 12, 0));
        layouts[4].Add(new Vector3Int(4, 13, 1));
        layouts[4].Add(new Vector3Int(4, 14, 0));
        layouts[4].Add(new Vector3Int(4, 15, 0));
        layouts[4].Add(new Vector3Int(4, 16, 0));
        layouts[4].Add(new Vector3Int(4, 17, 0));
        layouts[4].Add(new Vector3Int(4, 18, 0));

        layouts[4].Add(new Vector3Int(10, 0, 1));

        layouts[4].Add(new Vector3Int(10, 4, 0));
        layouts[4].Add(new Vector3Int(10, 5, 0));
        layouts[4].Add(new Vector3Int(10, 6, 0));
        layouts[4].Add(new Vector3Int(10, 7, 0));
        layouts[4].Add(new Vector3Int(10, 8, 1));
        layouts[4].Add(new Vector3Int(10, 9, 0));
        layouts[4].Add(new Vector3Int(10, 10, 0));
        layouts[4].Add(new Vector3Int(10, 11, 0));
        layouts[4].Add(new Vector3Int(10, 12, 1));
        layouts[4].Add(new Vector3Int(10, 13, 0));
        layouts[4].Add(new Vector3Int(10, 14, 0));

        layouts[4].Add(new Vector3Int(10, 18, 0));

        layouts[4].Add(new Vector3Int(16, 0, 0));
        layouts[4].Add(new Vector3Int(16, 1, 0));
        layouts[4].Add(new Vector3Int(16, 2, 0));
        layouts[4].Add(new Vector3Int(16, 3, 1));
        layouts[4].Add(new Vector3Int(16, 4, 0));
        layouts[4].Add(new Vector3Int(16, 5, 0));
        layouts[4].Add(new Vector3Int(16, 6, 0));
        layouts[4].Add(new Vector3Int(16, 7, 0));

        layouts[4].Add(new Vector3Int(16, 11, 0));
        layouts[4].Add(new Vector3Int(16, 12, 0));
        layouts[4].Add(new Vector3Int(16, 13, 0));
        layouts[4].Add(new Vector3Int(16, 14, 0));
        layouts[4].Add(new Vector3Int(16, 15, 0));
        layouts[4].Add(new Vector3Int(16, 16, 0));
        layouts[4].Add(new Vector3Int(16, 17, 0));
        layouts[4].Add(new Vector3Int(16, 18, 0));
        layouts[4].Add(new Vector3Int(22, 0, 0));

        layouts[4].Add(new Vector3Int(22, 4, 0));
        layouts[4].Add(new Vector3Int(22, 5, 0));
        layouts[4].Add(new Vector3Int(22, 6, 0));
        layouts[4].Add(new Vector3Int(22, 7, 1));
        layouts[4].Add(new Vector3Int(22, 8, 0));
        layouts[4].Add(new Vector3Int(22, 9, 0));
        layouts[4].Add(new Vector3Int(22, 10, 0));
        layouts[4].Add(new Vector3Int(22, 11, 0));
        layouts[4].Add(new Vector3Int(22, 12, 0));
        layouts[4].Add(new Vector3Int(22, 13, 0));
        layouts[4].Add(new Vector3Int(22, 14, 0));

        layouts[4].Add(new Vector3Int(22, 18, 1));


        layouts[4].Add(new Vector3Int(3, 5, 0));
        layouts[4].Add(new Vector3Int(5, 5, 0));

        layouts[4].Add(new Vector3Int(9, 5, 0));
        layouts[4].Add(new Vector3Int(11, 5, 0));

        layouts[4].Add(new Vector3Int(15, 5, 0));
        layouts[4].Add(new Vector3Int(17, 5, 0));

        layouts[4].Add(new Vector3Int(21, 5, 1));
        layouts[4].Add(new Vector3Int(23, 5, 0));
        layouts[4].Add(new Vector3Int(24, 5, 0));
        layouts[4].Add(new Vector3Int(25, 5, 0));
        layouts[4].Add(new Vector3Int(26, 5, 0));

        layouts[4].Add(new Vector3Int(3, 13, 0));
        layouts[4].Add(new Vector3Int(5, 13, 0));
        layouts[4].Add(new Vector3Int(6, 13, 0));
        layouts[4].Add(new Vector3Int(7, 13, 1));
        layouts[4].Add(new Vector3Int(8, 13, 0));
        layouts[4].Add(new Vector3Int(9, 13, 0));
        layouts[4].Add(new Vector3Int(11, 13, 0));

        layouts[4].Add(new Vector3Int(15, 13, 0));
        layouts[4].Add(new Vector3Int(17, 13, 0));

        layouts[4].Add(new Vector3Int(21, 13, 0));
        layouts[4].Add(new Vector3Int(23, 13, 1));

    }

    public static List<Vector3Int> getLayout(int level)
    {
        return layouts[level - 1];
    }
}
