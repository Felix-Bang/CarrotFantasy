//  Felix-Bang：MVC（中间量）
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
    public static class MVC
    {
        //存储MVC
        public static Dictionary<string, Model> Models = new Dictionary<string, Model>();       //名字---模型
        public static Dictionary<string, View> Views = new Dictionary<string, View>();          //名字---视图
        public static Dictionary<string, Type> CommandMap = new Dictionary<string, Type>();    //事件---控制器类型

        public static void RegisterModel(Model model)
        {
            Models[model.name] = model;
        }

        public static void RegisterView(View view)
        {
            Views[view.name] = view;
        }

        public static void RegisterController(string eventName,Type controllerType)
        {
            CommandMap[eventName] = controllerType;
        }

        public static Model GetModel<T>()
            where T:Model
        {
            foreach (Model m in Models.Values)
            {
                if (m is T)
                    return m;
            }

            return null;
        }

        public static View GetView<T>()
           where T : View
        {
            foreach (View v in Views.Values)
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
                Controller c = Activator.CreateInstance<Controller>();
                c.Execute(data);
            }

            //视图响应
            foreach (View v in Views.Values)
            {
                if (v.EventLists.Contains(eventName))
                    v.HandleEvent(eventName, data);
            }
        }
    }
}

