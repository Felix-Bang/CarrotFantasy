//  Felix-Bang：FBController
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
// Describe：控制器基类：协调M和V之间的交互，无需实例化，动态创建执行命令
//           1. 获取到模型和视图，并且调用方法
//           2. 处理视图发出的事件
// Createtime：2018/9/19


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FBFramework
{
	public abstract class FBController
	{
        /// <summary> 获取Model </summary>
        protected T GetModel<T>()
            where T : FBModel
        {
            return FBMVC.GetModel<T>() as T;
        }

        /// <summary> 获取View </summary>
        protected T GetView<T>()
           where T : FBView
        {
            return FBMVC.GetView<T>() as T;
        }

        /// <summary> 注册新Model </summary>
        protected void RegisterModel(FBModel model)
        {
            FBMVC.RegisterModel(model);
        }

        /// <summary> 注册新View </summary>
        protected void RegisterView(FBView view)
        {
            FBMVC.RegisterView(view);
        }

        /// <summary> 注册新Controller </summary>
        protected void RegisterController(string eventName, Type controllerType)
        {
            FBMVC.RegisterController(eventName, controllerType);
        }

        // 处理事件
        public abstract void Execute(object data = null);
        
	}
}

