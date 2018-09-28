//  Felix-Bang：FBBat
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
// Describe：蝙蝠的动画
// Createtime：2018/9/25


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FBApplication
{
	public class FBBat : MonoBehaviour
	{
        public float Time = 1;
        public float OffsetY = 8;

        void Start()
        {
            iTween.MoveBy(gameObject, iTween.Hash(
                "y", OffsetY,
                "easeType", iTween.EaseType.easeInOutSine,
                "loopType", iTween.LoopType.pingPong,
                "time",Time ));
        }
    }
}

