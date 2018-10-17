//  Felix-Bang：FBTowerInfo
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
// Describe：炮塔信息
// Createtime：2018/10/16

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FBApplication
{
	public class FBTowerInfo 
	{
        /// <summary> ID </summary>
        public int ID;
        /// <summary> 预制件 </summary>
        public string PrefabName;
        /// <summary> 正常图标 </summary>
        public string NormalIcon;
        /// <summary> 失效图标 </summary>
        public string DisabledIcon;
        /// <summary> 最高等级 </summary>
        public int MaxLevel;
        /// <summary> 价格 </summary>
        public int BasePrice;
        /// <summary> 射击频率 </summary>
        public int ShotRate;
        /// <summary> 警戒范围 </summary>
        public float GuardRange;
        /// <summary> 子弹ID </summary>
        public int UseBulletID;
    }
}
