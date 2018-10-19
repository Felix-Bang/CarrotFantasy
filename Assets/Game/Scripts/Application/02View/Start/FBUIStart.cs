//  Felix-Bang：FBUIStart
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
// Describe：开始界面
// Createtime：2018/9/25


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FBFramework;

namespace FBApplication
{
	public class FBUIStart : FBView
	{
        public override string Name
        {
            get { return FBConsts.V_Start; }
        }

        public void GotoSelect()
        {
            FBGame.Instance.LoadScene(2);
        }

        public override void HandleEvent(string eventName, object data = null) {}
	}
}

