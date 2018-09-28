//  Felix-Bang：FBGame
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
// Describe：启动游戏 初始化全局数据
// Createtime：2018/9/25


using UnityEngine;
using UnityEngine.SceneManagement;
using FBFramework;
using System;

namespace FBApplication
{
    [RequireComponent(typeof(FBObjectPool))]
    [RequireComponent(typeof(FBSound))]
    [RequireComponent(typeof(FBStaticData))]
    public class FBGame : FBApplicationBase<FBGame>
	{
        // 全局访问功能
        [HideInInspector]
        public FBObjectPool ObjectPool=null;
        [HideInInspector]
        public FBSound Sound = null;
        [HideInInspector]
        public FBStaticData Data = null;

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneWasLoaded;
        }

        // 游戏入口
        void Start ()
		{
            DontDestroyOnLoad(gameObject);

            //赋值
            ObjectPool = FBObjectPool.Instance;
            Sound = FBSound.Instance;
            Data = FBStaticData.Instance;

            //注册命令（Command）
            RegisterController(FBConsts.E_StartUp, typeof(FBStartUpCommand));

            //启动游戏
            SendEvent(FBConsts.E_StartUp);

        }

        /// <summary>
        /// 加载场景
        /// </summary>
        /// <param name="index">场景索引</param>
        public void LoadScene(int index)
        {
            //推出旧场景
            //事件参数
            FBSceneArgs e = new FBSceneArgs
            {
                Index = SceneManager.GetActiveScene().buildIndex
            };
            //发布事件
            SendEvent(FBConsts.E_ExitScene,e);

            //加载新场景
            SceneManager.LoadScene(index,LoadSceneMode.Single);
        }

        // 当前场景加载后触发
        private void OnSceneWasLoaded(Scene arg0, LoadSceneMode arg1)
        {
            FBSceneArgs e = new FBSceneArgs
            {
                Index = arg0.buildIndex
            };

            SendEvent(FBConsts.E_EnterScene, e);
        }

        // 当前场景加载后触发
        //private void OnLevelWasLoaded(int index)
        //{
        //    FBSceneArgs e = new FBSceneArgs
        //    {
        //        Index = index
        //    };

        //    SendEvent(FBConsts.E_EnterScene,e);
        //}

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneWasLoaded;
        }
    }
}

