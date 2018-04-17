using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My.Disk
{
    public class DiskFactory : MonoBehaviour
    {

        private static List<GameObject> used = new List<GameObject>();
        // 正在使用的对象链表
        private static List<GameObject> free = new List<GameObject>();
        // 正在空闲的对象链表

        DiskInfo inf;

        private void Start()
        {
            inf = new DiskInfo();
        }

        // 此函数表示将Target物体放到一个位置
        public GameObject setDiskOnPos(Vector3 targetposition)
        {
            if (free.Count == 0)
            {
                GameObject aGameObject = Instantiate(Resources.Load("prefabs/disk")
                    , targetposition, Quaternion.identity) as GameObject;
                // 新建实例，将位置设置成为targetposition
                used.Add(aGameObject);
            }
            else
            {
                used.Add(free[0]);
                free.RemoveAt(0);
                used[used.Count - 1].SetActive(true);
                used[used.Count - 1].transform.position = targetposition;
                inf.processDisk(used[used.Count - 1]);
                // 加工disk
            }
            return used[used.Count - 1];
        }

        public void freeDisk(GameObject oj)
        {
            oj.SetActive(false);
            used.Remove(oj);
            free.Add(oj);
            
        }
    }
}