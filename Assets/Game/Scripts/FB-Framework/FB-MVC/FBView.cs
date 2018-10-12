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
// Describe：界面的基类(需要挂载到游戏对象)
//           1. 查询模型（调用模型的方法），接收模型发送的消息
//           2. 处理消息
//           3. 向控制器发送消息
// Createtime：2018/9/19


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FBFramework
{
	public abstract class FBView : MonoBehaviour
	{
        /// <summary> 名称：用于检索 </summary>
        public abstract string Name { get; }
        /// <summary> View相关的事件列表 </summary>
        [HideInInspector]
        public List<string> EventLists = new List<string>();

        /// <summary>
        /// 事件处理
        /// </summary>
        /// <param name="eventName">事件名称</param>
        /// <param name="data">携带信息</param>
        public abstract void HandleEvent(string eventName, object data = null);

        // 注册关心的事件
        public virtual void RegisterEvents() {}

        /// <summary> 获取模型 </summary>
        protected T GetModel<T>()
            where T : FBModel
        {
            return FBMVC.GetModel<T>() as T;
        }

        // 发送事件
        protected void SendEvent(string eventName, object data = null)
        {
            FBMVC.SendEvent(eventName, data);
        }
    }
}

