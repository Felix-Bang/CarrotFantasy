//  Felix-Bang：FBStartUpCommand
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
    public class FBStartUpCommand : FBController
    {
        public override void Execute(object data = null)
        {
            //注册模型（Model）

            //注册命令（Command）
            RegisterController(FBConsts.E_EnterScene, typeof(FBEnterSceneCommand));
            RegisterController(FBConsts.E_ExitScene, typeof(FBExitSceneCommand));

            //进入开始界面
            FBGame.Instance.LoadScene(1);
        }
    }
}

