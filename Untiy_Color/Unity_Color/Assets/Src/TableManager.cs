using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using yijianyouxie.Log;
using LitJson;
using yijianyouxie.Data;

namespace yijianyouxie.Table
{
    public class TableManager : MonoBehaviour
    {
        public TextAsset levelText;
        // Start is called before the first frame update
        void Start()
        {
            if(null == levelText)
            {
                LogSystem.Error("====levelText is null.");
                return;
            }

            var levelStr = levelText.text;

            JsonData jd = JsonMapper.ToObject(levelStr);

            if(null != jd)
            {
                var levelCount = jd.Count;
                for(int i = 0; i < levelCount; i++)
                {
                    var jsonLevelData = jd[i];

                    var levelData = new LevelData();

                    int.TryParse(jsonLevelData["Level"].ToString(), out levelData.level);
                    int.TryParse(jsonLevelData["LineNum"].ToString(), out levelData.lineNum);
                    int.TryParse(jsonLevelData["ColumnNum"].ToString(), out levelData.columnNum);

                    LevelDataList.levelDataList.Add(levelData);
                }


                EventManager.SendEvent(DataEvent.TableLoaded);
            }
        }
    }
}