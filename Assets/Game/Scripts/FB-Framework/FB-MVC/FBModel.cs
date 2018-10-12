//  Felix-Bang：FBModel
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
// Describe：所有数据模型的基类，不需要实例化
//           Model不需要引用View和Controller中的方法，只需要发送消息即可
// Createtime：2018/9/19


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FBFramework
{
	public abstract class FBModel
	{
        /// <summary> 名称：用于检索 </summary>
		public abstract string Name { get; }

        /// <summary>
        /// 发送事件
        /// </summary>
        /// <param name="eventName">时间名</param>
        /// <param name="data">携带数据信息</param>
        protected void SendEvent(string eventName, object data = null)
        {
            FBMVC.SendEvent(eventName,data);
        }
    }
}

