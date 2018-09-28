//  Felix-Bang：FBController（协调M和V）
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
	public abstract class FBController
	{
        protected FBModel GetModel<T>()
            where T : FBModel
        {
            return FBMVC.GetModel<T>();
        }

        protected FBView GetView<T>()
           where T : FBView
        {
            return FBMVC.GetView<T>();
        }

        protected void RegisterModel(FBModel model)
        {
            FBMVC.RegisterModel(model);
        }

        protected void RegisterView(FBView view)
        {
            FBMVC.RegisterView(view);
        }

        protected void RegisterController(string eventName, Type controllerType)
        {
            FBMVC.RegisterController(eventName, controllerType);
        }

        public abstract void Execute(object data = null);
        
	}
}

