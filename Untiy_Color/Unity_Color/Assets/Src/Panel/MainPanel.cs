using Games.TLBB.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using yijianyouxie.Data;
using yijianyouxie.Log;
using System;

namespace yijianyouxie.Panel
{
    public class MainPanel : MonoBehaviour
    {
        public UILabel lbl_tableStr;
        public GameObject obj_cellItem;
        public UITable table_cellList;

        private List<CellItem> list_cell = new List<CellItem>();
        private List<Color> list_color = new List<Color>();
        private int firstIndex = -1;
        private int secondIndex = -1;

        // Start is called before the first frame update
        void Start()
        {
            //EventManager.RegistDelegate(DataEvent.TableLoaded, TableLoaded);
            EventManager.RegistDelegate(DataEvent.StartGameWithLevel, StartGame);

            if(null != obj_cellItem)
            {
                obj_cellItem.SetActive(false);
            }
        }


        private void StartGame(object[] param)
        {
            int currLevel = GameUtil.GetConvetedInt(param[0]);

            InitData(currLevel);
            UpdatePage();
        }

        private void InitData(int level)
        {
            list_color.Clear();

            var levelDataList = LevelDataList.levelDataList;
            if (null != levelDataList)
            {
                var levelData = levelDataList[level - 1];
                if (null != levelData)
                {
                    //计算需要多少个
                    var lineNum = levelData.lineNum;
                    var columnNum = levelData.columnNum;
                    var totalNum = lineNum * columnNum;//一定要是偶数

                    //设置table的列数
                    if(null != table_cellList)
                    {
                        table_cellList.columns = columnNum;
                    }

                    var minR = levelData.minR;
                    var minG = levelData.minG;
                    var minB = levelData.minB;

                    var maxR = levelData.maxR;
                    var maxG = levelData.maxG;
                    var maxB = levelData.maxB;

                    var unitNum = (totalNum / 2);
                    var unitR = (maxR - minR) / unitNum;
                    var unitG = (maxG - minG) / unitNum;
                    var unitB = (maxB - minB) / unitNum;

                    for(int i = 0; i < unitNum; i++)
                    {
                        float r = minR + unitR * i;
                        float g = minG + unitG * i;
                        float b = minB + unitB * i;
                        //Color color = new Color(r/255, g/255, b/255);//rgb模式
                        Color color = HSL2RGB(r/360f, g/100f, b/100f);//hsl模式
                        //LogSystem.Error("========color = {0},r:{1},g:{2},b{3}", color, r, g, b);
                        list_color.Add(color);
                        list_color.Add(color);
                    }

                    list_color = RandomList(list_color);
                }
            }
        }
        private List<T> RandomList<T>(List<T> list)
        {
            System.Random random = new System.Random();
            for (int i = 0; i < list.Count; i++)
            {
                T temp;
                int j = random.Next(0, list.Count - 1);
                //交换两个数据的值
                temp = list[j];
                list[j] = list[i];
                list[i] = temp;
            }
            return list;

        }

        private void UpdatePage()
        {
            list_cell.Clear();            

            CellItem cellItem;
            for(int i = 0; i < list_color.Count; i++)
            {
                if(list_cell.Count > i)
                {
                    cellItem = list_cell[i];
                }
                else
                {
                    var objItem = NGUITools.AddChild(table_cellList.gameObject, obj_cellItem);
                    cellItem = objItem.GetComponent<CellItem>();

                    list_cell.Add(cellItem);
                }

                cellItem.gameObject.SetActive(true);
                cellItem.cellIndex = i;
                cellItem.SetCellColor(list_color[i]);
            }

            //隐藏多余
            for(int i = list_color.Count; i < list_cell.Count; i++)
            {
                CellItem ci = list_cell[i];
                if(null != ci)
                {
                    ci.gameObject.SetActive(false);
                }
            }

            table_cellList.Reposition();

            //修正位置
            var bound = NGUIMath.CalculateRelativeWidgetBounds(table_cellList.gameObject.transform, false);
            var tableWidth = bound.extents.x * 2;
            var tableHeight = bound.extents.y * 2;
            table_cellList.transform.localPosition = new Vector3(-tableWidth/2, GameManager.ScreenHeight/2 - 10, 0);
        }

        public void OnClickItem(CellItem cellItem)
        {
            if(null == cellItem)
            {
                LogSystem.Error("========cellItem is null.");
                return;
            }

            int index = cellItem.cellIndex;
            cellItem.obj_selected.SetActive(true);
            //LogSystem.Error("====index = {0}", index);

            if(firstIndex >= 0)
            {
                if(firstIndex != index)
                {
                    secondIndex = index;
                }else
                {
                    return;
                }
            }else
            {
                firstIndex = index;
            }

            if(firstIndex >= 0 && secondIndex >= 0 && firstIndex != secondIndex)
            {
                //检测颜色是否相等
                if(list_color[firstIndex] == list_color[secondIndex])
                {
                    //格子消失
                    list_cell[firstIndex].gameObject.SetActive(false);
                    list_cell[secondIndex].gameObject.SetActive(false);
                }
                else
                {
                    //选中框消失
                    list_cell[firstIndex].obj_selected.SetActive(false);
                    list_cell[secondIndex].obj_selected.SetActive(false);
                }

                firstIndex = secondIndex = -1;
            }
        }

        private Color HSL2RGB(double H, double S, double L)
        {
            int R, G, B = 0;
            //此处HSL均转化到(0, 1)
            double var1, var2;
            if (S == 0)
            {
                R = (int)(L * 255.0);
                G = (int)(L * 255.0);
                B = (int)(L * 255.0);
            }
            else
            {
                if (L < 0.5)
                    var2 = L * (1 + S);
                else
                    var2 = (L + S) - (S * L);
                var1 = 2.0 * L - var2;

                R = (int)(255.0 * Hue2RGB(var1, var2, H + (1.0 / 3.0)));
                G = (int)(255.0 * Hue2RGB(var1, var2, H));
                B = (int)(255.0 * Hue2RGB(var1, var2, H - (1.0 / 3.0)));
            }

            return new Color(R/255f,G/255f,B/255f);
        }

        private double Hue2RGB(double v1, double v2, double vH)
        {
            if (vH < 0)
                vH += 1;
            if (vH > 1)
                vH -= 1;
            if (6.0 * vH < 1)
                return v1 + (v2 - v1) * 6.0 * vH;
            if (2.0 * vH < 1)
                return v2;
            if (3.0 * vH < 2)
                return v1 + (v2 - v1) * ((2.0 / 3.0) - vH) * 6.0;
            return (v1);
        }
    }
}
