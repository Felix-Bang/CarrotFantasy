//  Felix-Bang：FBBottle
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
// Describe：
// Createtime：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FBApplication
{
	public class FBBottle : FBTower
	{
		#region 常量
        #endregion

        #region 事件
        #endregion

        #region 字段
        #endregion

        #region 属性
        #endregion


        #region 事件回调
        #endregion

        #region 方法
        protected override void Attack()
        {
            if (f_animator.gameObject.activeSelf)
                f_animator.SetTrigger("IsAttack");
        }

        public override void OnSpawn()
        {
            base.OnSpawn();
        }

        public override void OnUnspawn()
        {
            base.OnUnspawn();
        }
        #endregion

        #region 帮助方法
        #endregion
    }
}
