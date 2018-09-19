//  Felix-Bang：SubPool
//　　 へ　　　　　／|
//　　/＼7　　　 ∠＿/
//　 /　│　　 ／　／
//　│　Z ＿,＜　／　　 /`ヽ
//　│　　　　　ヽ　　 /　　〉
//　 Y　　　　　`　 /　　/
//　ｲ●　､　●　　⊂⊃〈　　/
//　()　 へ　　　　|　＼〈
//　　>ｰ ､_　 ィ　 │ ／／
//　 / へ　　 /　ﾉ＜| ＼＼
//　 ヽ_ﾉ　　(_／　 │／／
//　　7　　　　　　　|／
//　　＞―r￣￣`ｰ―＿

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FBFramework
{
	public class SubPool : MonoBehaviour
	{
        GameObject f_prefab;
        List<GameObject> f_objects = new List<GameObject>();

        /// <summary> 名称标识 </summary>      
        public string Name
        {
            get { return f_prefab.name; }
        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="prefab"> 预制件 </param>
        public SubPool(GameObject prefab)
        {
            f_prefab = prefab;
        }

        /// <summary> 创建对象 </summary>
        public GameObject Spawn()
        {
            GameObject go = null;

            foreach (var obj in f_objects)
            {
                if (!obj.activeSelf)
                {
                    go = obj;
                    break;
                }
            }

            if (go == null)
            {
                go = GameObject.Instantiate<GameObject>(f_prefab);
                f_objects.Add(go);
            }

            go.SetActive(true);
            go.SendMessage("OnSpawn", SendMessageOptions.DontRequireReceiver);
            return go;
        }

        /// <summary> 回收对象 </summary>
        public void Unspawn(GameObject go)
        {
            if (IsContains(go))
            {
                go.SendMessage("OnUnspawn", SendMessageOptions.DontRequireReceiver);
                go.SetActive(false);
            }
        }

        /// <summary> 回收本对象池全部对象 </summary>
        public void UnspawnAll()
        {
            foreach (var item in f_objects)
            {
                if (item.activeSelf)
                    Unspawn(item);
            }
        }

        /// <summary>
        /// 对象池是否包含对象
        /// </summary>
        /// <param name="go">目标对象</param>
        /// <returns></returns>
        public bool IsContains(GameObject go)
        {
            return f_objects.Contains(go);
        }
    }
}

