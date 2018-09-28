//  Felix-Bang：FBApplicationBase
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
// Describe：
// Createtime：2018/9/19


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FBFramework
{
	public abstract class FBApplicationBase<T>:FBSingleton<T>
        where T : MonoBehaviour
    {

        protected void RegisterController(string eventName, Type controllerType)
        {
            FBMVC.RegisterController(eventName, controllerType);
        }

        protected void SendEvent(string eventName,object data=null)
        {
            FBMVC.SendEvent(eventName,data);
        }
    }
}

