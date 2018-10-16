//  Felix-Bang：FBCountDownCompleteController
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
// Describe：倒计时结束控制器
// Createtime：2018/10/12

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FBFramework;

namespace FBApplication
{
	public class FBCountDownCompleteController : FBController
	{
        public override void Execute(object data = null)
        {
            //出怪
            FBRoundModel roundModel = GetModel<FBRoundModel>();
            roundModel.StartRound();
        }
	}
}
