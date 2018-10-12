//  Felix-Bang：FBStartUpController
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
// Describe：启动游戏控制器
// Createtime：2018/9/26


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FBFramework;

namespace FBApplication
{
    public class FBStartUpController : FBController
    {
        public override void Execute(object data = null)
        {
            //注册模型（Model）
            RegisterModel(new FBGameModel());

            //注册命令（Command）
            RegistControllers();

            //初始化
            FBGameModel gameModel = GetModel<FBGameModel>();
            gameModel.OnInitialized();

            //进入开始界面
            FBGame.Instance.LoadScene(1);
        }

        private void RegistControllers()
        {
            RegisterController(FBConsts.E_SceneEnter, typeof(FBSceneEnterController));
            RegisterController(FBConsts.E_SceneExit, typeof(FBSceneExitController));
            RegisterController(FBConsts.E_LevelStart, typeof(FBLevelStartController));
            RegisterController(FBConsts.E_LevelEnd, typeof(FBLevelEndController));
        }
    }
}

