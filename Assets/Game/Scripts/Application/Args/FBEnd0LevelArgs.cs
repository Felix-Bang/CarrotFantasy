//  Felix-Bang：FBEnd0LevelArgs
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
// Describe：结束关卡的事件参数
// Createtime：2018/9/27


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FBApplication
{
	public class FBEnd0LevelArgs
    {
        /// <summary> 关卡索引 </summary>
        public int Index { get; set; }
        /// <summary>
        /// 结束类型：闯关成功（true）/失败（false）
        /// </summary>
        public bool IsSuccess;
	}
}

