//  Felix-Bang：FBView
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
// Describe：(需要挂载到游戏对象)
// Createtime：2018/9/19


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FBFramework
{
	public abstract class FBView : MonoBehaviour
	{
        public abstract string Name { get; }
        [HideInInspector]
        public List<string> EventLists = new List<string>();

        public abstract void HandleEvent(string eventName, object data = null);

        public virtual void RegisterEvents()
        { }

        protected FBModel GetModel<T>()
            where T : FBModel
        {
            return FBMVC.GetModel<T>();
        }

        protected void SendEvent(string eventName, object data = null)
        {
            FBMVC.SendEvent(eventName, data);
        }
    }
}

