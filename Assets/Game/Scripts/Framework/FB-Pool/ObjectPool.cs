//  Felix-Bang：ObjectPool
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
// Describe：对象池
// Createtime：2018/9/18


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FelixPool
{
	public class ObjectPool : MonoBehaviour
	{
        string f_resourceDir = "";
        Dictionary<string, SubPool> f_pools = new Dictionary<string, SubPool>();

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <param name="name"> 对象名</param>
        /// <returns></returns>
        public GameObject Spawn(string name)
        {
            if (!f_pools.ContainsKey(name))
                RegisterNewPool(name);

            SubPool pool = f_pools[name];
            return pool.Spawn();
        }

        /// <summary> 回收对象 </summary>
        public void Unspawn(GameObject go)
        {
            SubPool pool = null;

            foreach (SubPool p in f_pools.Values)
            {
                if (p.IsContains(go))
                {
                    pool = p;
                    break;
                }
            }

            pool.Unspawn(go);
        }

        /// <summary> 回收所有对象 </summary>
        public void UnspawnAll()
        {
            foreach (SubPool p in f_pools.Values)
                p.UnspawnAll();
        }

        /// <summary> 创建一个新的SubPool </summary>
        void RegisterNewPool(string name)
        {
            string path = "";
            if (string.IsNullOrEmpty(f_resourceDir))
                path = name;
            else
                path = f_resourceDir + "/" + name;

            GameObject prefab = Resources.Load<GameObject>(path);

            SubPool pool = new SubPool(prefab);
            f_pools.Add(pool.name, pool);
        }
    }

}

