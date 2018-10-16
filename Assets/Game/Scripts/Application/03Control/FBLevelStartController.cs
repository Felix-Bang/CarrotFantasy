//  Felix-Bang：FBLevelStartController
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
// Createtime：2018/9/19


using FBFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FBApplication
{
	public class FBLevelStartController : FBController
    {
        public override void Execute(object data = null)
        {
            FBStartLevelArgs e = data as FBStartLevelArgs;
            //第一步
            FBGameModel gameModel = GetModel<FBGameModel>();
            gameModel.StartLevel(e.ID);
            
            //第二步
            FBRoundModel roundModel = GetModel<FBRoundModel>();
            roundModel.LoadLevel(gameModel.PlayLevel);

            // 进入游戏
            FBGame.Instance.LoadScene(3);
        }

     
	}
}

