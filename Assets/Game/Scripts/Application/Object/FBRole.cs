//  Felix-Bang：FBRole
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
// Describe：角色色基类
// Createtime：2018/10/15

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FBFramework;
using System;

namespace FBApplication
{
    public abstract class FBRole : FBReusableObject, IFBReusable
    {

        #region 常量
        #endregion

        #region 事件
        public event Action<int, int> HPChangedAction;             //血量变化事件
        public event Action<FBRole> DeadAction;             //死亡事件
        #endregion

        #region 字段
        int f_hp;
        int f_maxHp;

        #endregion

        #region 属性
        public int HP
        {
            get { return f_hp; }
            set
            {
                value = Mathf.Clamp(value, 0, f_maxHp);

                if (value == f_hp)
                    return;

                f_hp = value;
                if (HPChangedAction != null)
                    HPChangedAction(f_hp, f_maxHp);

                if (f_hp == 0)
                {
                    if (DeadAction != null)
                        DeadAction(this);
                }
            }
        }

        public int MaxHP
        {
            get { return f_maxHp; }
            set
            {
                if (value < 0)
                    value = 0;

                f_maxHp = value;
            }
        }

        public bool IsDead
        {
            get { return f_hp == 0; }
        }

    
        #endregion

        #region Unity回调
        void Start () 
		{
			
		}
	
		void Update ()
		{
			
		}
        #endregion

        #region 事件回调
        public override void OnSpawn()
        {
            this.DeadAction += OnDie;
        }

        public override void OnUnspawn()
        {
            HP = 0;
            MaxHP = 0;

            while (HPChangedAction != null)
                HPChangedAction -= HPChangedAction;

            while (DeadAction != null)
                DeadAction -= DeadAction;
        }
        #endregion

        #region 方法
        public virtual void Damage(int hit)
        {
            if (IsDead)
                return;

            HP -= hit;
        }

        protected virtual void OnDie(FBRole role) {}
        #endregion

        #region 帮助方法
        #endregion
    }
}
