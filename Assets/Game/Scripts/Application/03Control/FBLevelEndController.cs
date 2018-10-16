//  Felix-Bang：FBLevelEndController
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
// Describe：开始关卡控制器
// Createtime：


using FBFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FBApplication
{
	public class FBLevelEndController : FBController
    {
        public override void Execute(object data = null)
        {
            FBEndLevelArgs e = data as FBEndLevelArgs;

            //保存游戏状态
            FBGameModel gameModel = GetModel<FBGameModel>();
            gameModel.StoptLevel(e.IsWin);

            //弹出UI
            if (e.IsWin)
            {
                GetView<FBUIWin>().Show();
            }
            else
            {
                GetView<FBUILost>().Show();
            }


        }

   
	}
}

