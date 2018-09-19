//  Felix-Bang：Controller（协调M和V）
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
// Createtime：


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FBFramework
{
	public abstract class Controller : MonoBehaviour
	{
        protected Model GetModel<T>()
            where T : Model
        {
            return MVC.GetModel<T>();
        }

        protected View GetView<T>()
           where T : View
        {
            return MVC.GetView<T>();
        }

        protected void RegisterModel(Model model)
        {
            MVC.RegisterModel(model);
        }

        protected void RegisterView(View view)
        {
            MVC.RegisterView(view);
        }

        protected void RegisterController(string eventName, Type controllerType)
        {
            MVC.RegisterController(eventName, controllerType);
        }

        public abstract void Execute(object data = null);
        
	}
}

