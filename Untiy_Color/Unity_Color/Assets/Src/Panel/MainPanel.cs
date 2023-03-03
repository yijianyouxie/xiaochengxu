using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using yijianyouxie.Data;
using yijianyouxie.Log;

namespace yijianyouxie.Panel
{
    public class MainPanel : MonoBehaviour
    {

        public UILabel lbl_tableStr;

        // Start is called before the first frame update
        void Start()
        {
            EventManager.RegistDelegate(DataEvent.TableLoaded, TableLoaded);
        }

        // Update is called once per frame
        //void Update()
        //{
        
        //}


        private void TableLoaded(object[] param)
        {
            LogSystem.Error("==================表格加载完了。");

            if(null != lbl_tableStr)
            {
                string str = string.Empty;
                int len = LevelDataList.levelDataList.Count;
                for(int i = 0; i < len; i++)
                {
                    var data = LevelDataList.levelDataList[i];
                    str += data.level + " " + data.lineNum + " " + data.columnNum;
                }

                lbl_tableStr.text = str;
            }
        }
    }
}
