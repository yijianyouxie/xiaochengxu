using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace yijianyouxie.Data
{
    public class LevelDataList
    {
        public static List<LevelData> levelDataList = new List<LevelData>();
    }

    public class LevelData
    {
        public int level = 0;
        public int lineNum = 0;
        public int columnNum = 0;

        public float minR = 0f;
        public float minG = 0f;
        public float minB = 0f;
        public float maxR = 0f;
        public float maxG = 0f;
        public float maxB = 0f;
    }
}

