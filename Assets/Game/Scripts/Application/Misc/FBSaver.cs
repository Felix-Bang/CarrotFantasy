//  Felix-Bang：FBSaver
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
// Describe：读档和存档
// Createtime：2018/10/11


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FBApplication
{
	public static class FBSaver
	{
        #region 方法
        public static int GetProgress()
        {
            return PlayerPrefs.GetInt(FBConsts.GameProgress,-1);

        }

        public static void SetProgress(int levelIndex)
        {
            PlayerPrefs.SetInt(FBConsts.GameProgress, levelIndex);
        }
		#endregion
	}
}

