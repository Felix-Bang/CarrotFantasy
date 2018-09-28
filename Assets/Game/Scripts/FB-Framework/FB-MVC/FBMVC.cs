//  Felix-Bang：FBMVC（中间量）
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
    public static class FBMVC
    {
        //存储MVC
        public static Dictionary<string, FBModel> Models = new Dictionary<string, FBModel>();       //名字---模型
        public static Dictionary<string, FBView> Views = new Dictionary<string, FBView>();          //名字---视图
        public static Dictionary<string, Type> CommandMap = new Dictionary<string, Type>();    //事件---控制器类型

        public static void RegisterModel(FBModel model)
        {
            Models[model.name] = model;
        }

        public static void RegisterView(FBView view)
        {
            //防止重复
            if (Views.ContainsKey(view.name))
                Views.Remove(view.name);

            view.RegisterEvents();
            Views[view.name] = view;
        }

        public static void RegisterController(string eventName,Type controllerType)
        {
            CommandMap[eventName] = controllerType;
        }

        public static FBModel GetModel<T>()
            where T:FBModel
        {
            foreach (FBModel m in Models.Values)
            {
                if (m is T)
                    return m;
            }

            return null;
        }

        public static FBView GetView<T>()
           where T : FBView
        {
            foreach (FBView v in Views.Values)
            {
                if (v is T)
                    return v;
            }

            return null;
        }

        //发送事件

        public static void SendEvent(string eventName, object data = null)
        {
            //控制器响应
            if (CommandMap.ContainsKey(eventName))
            {
                Type t = CommandMap[eventName];
                FBController c = Activator.CreateInstance(t) as FBController;
                c.Execute(data);
            }

            //视图响应
            foreach (FBView v in Views.Values)
            {
                if (v.EventLists.Contains(eventName))
                    v.HandleEvent(eventName, data);
            }
        }
    }
}

