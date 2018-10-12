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
// Describe：MVC的中间类，用于储存M、V、C，分发事件
// Createtime：2018/9/19


using System;
using System.Collections.Generic;

namespace FBFramework
{
    public static class FBMVC
    {
        //用字典存储MVC
        public static Dictionary<string, FBModel> Models = new Dictionary<string, FBModel>();       //名字---模型
        public static Dictionary<string, FBView> Views = new Dictionary<string, FBView>();          //名字---视图
        public static Dictionary<string, Type> CommandMap = new Dictionary<string, Type>();    //事件---控制器类型

        #region 注册功能
        /// <summary>
        /// 注册Model
        /// </summary>
        /// <param name="model">Model实例</param>
        public static void RegisterModel(FBModel model)
        {
            Models[model.Name] = model;
        }

        /// <summary>
        /// 注册View
        /// </summary>
        /// <param name="model">View实例</param>
        public static void RegisterView(FBView view)
        {
            //防止重复
            if (Views.ContainsKey(view.name))
                Views.Remove(view.name);

            view.RegisterEvents();
            Views[view.name] = view;
        }

        /// <summary>
        /// 注册控制器
        /// </summary>
        /// <param name="eventName">事件名称</param>
        /// <param name="controllerType">控制器类型</param>
        public static void RegisterController(string eventName,Type controllerType)
        {
            CommandMap[eventName] = controllerType;
        }
        #endregion

        #region 检索功能
        public static T GetModel<T>()
            where T:FBModel
        {
            foreach (FBModel m in Models.Values)
            {
                if (m is T)
                    return m as T;
            }

            return null;
        }

        public static T GetView<T>()
           where T : FBView
        {
            foreach (FBView v in Views.Values)
            {
                if (v is T)
                    return v as T;
            }

            return null;
        }
        #endregion

        /// <summary>
        /// 发送事件
        /// </summary>
        /// <param name="eventName">事件名称</param>
        /// <param name="data">携带信息（可空）</param>
        public static void SendEvent(string eventName, object data = null)
        {
            //控制器一般对变化有逻辑性的处理，然后返回一个处理结果；
            //View仅随变化实现相应的显示，
            //因此要先对控制器响应，再View

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

