using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace yijianyouxie.Panel
{
    public class CellItem : MonoBehaviour
    {
        public GameObject obj_selected;
        public UISprite sp_cell;

        public int cellIndex = 0;

        public void SetCellColor(Color color)
        {
            if(null != sp_cell)
            {
                sp_cell.color = color;
            }
        }
    }
}
