//  Felix-Bang：FBCloud
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
// Describe：云
// Createtime：2018/9/25


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FBApplication
{
	public class FBCloud : MonoBehaviour
	{
        public float OffsetX = 1000;
        public float Duration = 10;

        void Start()
        {
            iTween.MoveBy(gameObject, iTween.Hash(
                "x", OffsetX,
                "easeType", iTween.EaseType.linear,
                "loopType", iTween.LoopType.loop,
                "time", Duration));
        }
    }
}

