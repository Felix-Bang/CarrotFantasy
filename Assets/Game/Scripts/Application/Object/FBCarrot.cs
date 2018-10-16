//  Felix-Bang：FBCarrot
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
// Describe：萝卜
// Createtime：2018/10/15

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FBApplication
{
	public class FBCarrot : FBRole
	{
        #region 常量
        #endregion

        #region 事件

        #endregion

        #region 字段
        Animator f_animator;

        
        #endregion

        #region 属性
        #endregion

        #region Unity回调
        #endregion

        #region 事件回调
        public override void OnSpawn()
        {
            base.OnSpawn();
            f_animator = GetComponent<Animator>();
            if (f_animator.gameObject.activeSelf)
                f_animator.Play("Carrot_Idle");

            FBCarrotInfo info = FBGame.Instance.StaticData.GetCarrot();
            MaxHP = info.HP;
            HP = info.HP;
        }

        public override void OnUnspawn()
        {
            base.OnUnspawn();
            if (f_animator.gameObject.activeSelf)
            {
                f_animator.ResetTrigger("IsDamage");
                f_animator.SetBool("IsDead", false);
            }
        }
        #endregion

        #region 方法
        public override void Damage(int hit)
        {
            if (IsDead) return;
            base.Damage(hit);
            if(f_animator.gameObject.activeSelf)
                f_animator.SetTrigger("IsDamage");
        }

        protected override void OnDie(FBRole role)
        {
            base.OnDie(role);
            if (f_animator.gameObject.activeSelf)
                f_animator.SetBool("IsDead",true);
        }
        #endregion

        #region 帮助方法
        #endregion
    }
}
