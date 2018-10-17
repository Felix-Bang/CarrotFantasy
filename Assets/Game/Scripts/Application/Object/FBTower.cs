//  Felix-Bang：FBTower
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
using FBFramework;
using System;

namespace FBApplication
{
	public abstract class FBTower : FBReusableObject, IFBReusable
    {
        #region 字段
        protected Animator f_animator;
        [SerializeField] int f_level=0;
        FBMonster f_target = null;
        float f_lastShotTime = 0;
        FBGrid f_grid;
        #endregion

        #region 属性
        public FBGrid Tile { get; private set; }
        public int ID { get; private set; }
        public int MaxLevel { get; private set; }
        public int Level
        {
            get { return f_level; }
            set
            {
                f_level = Mathf.Clamp(value, 0, MaxLevel);
                transform.localScale = Vector3.one * (1 + f_level);
            }
        }
        public bool IsTopLevel { get { return Level >= MaxLevel; } }
        public float ShotRate { get; private set; }
        public float GuardRange { get; private set; }
        private int BasePrice { get; set; }
        private int UseBulletID { get; set; }
        public int Price { get { return BasePrice * Level; } }
        #endregion

        #region Unity回调
        void Update()
        {
            if (f_target == null)
            {
                GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");
                for (int i = 0,max = monsters.Length; i < max; i++)
                {
                    FBMonster m = monsters[i].GetComponent<FBMonster>();
                    float dis = Vector3.Distance(m.transform.position, transform.position);
                    if (!m.IsDead && dis <= GuardRange)
                    {
                        f_target = m;
                        break;
                    }
                }
            }
            else
            {
                float dis = Vector3.Distance(f_target.transform.position, transform.position);
                if (!f_target.IsDead && dis > GuardRange)
                {
                    f_target = null;
                    return;
                }

                float attackTime = f_lastShotTime + 1f / ShotRate;
                if (Time.time >= attackTime)
                {
                    //转向目标
                    LookAtTarget();
                    Attack();
                    f_lastShotTime = Time.time;
                }
            }
        }

      
        #endregion


        #region 方法
        public void Load(int towerId,FBGrid grid)
        {
            FBTowerInfo info = FBGame.Instance.StaticData.GetTower(towerId);
            ID = info.ID;
            MaxLevel = info.MaxLevel;
            BasePrice = info.BasePrice;
            GuardRange = info.GuardRange;
            ShotRate = info.ShotRate;
            UseBulletID = info.UseBulletID;
            Level = 1;
            f_grid = grid;
        }

        private void LookAtTarget()
        {
           
        }

        protected virtual void Attack() {}

        public override void OnSpawn()
        {
            f_animator = GetComponent<Animator>();
            f_animator.Play("Bottle_Idle");
        }

        public override void OnUnspawn()
        {
            if (f_animator.gameObject.activeSelf)
                f_animator.ResetTrigger("IsAttack");

            f_animator = null;
            f_target = null;
            ID = 0;
            Level = 0;
            MaxLevel = 0;
            BasePrice = 0;
            GuardRange = 0;
            ShotRate = 0;
            UseBulletID = 0;
        }
        #endregion


    }
}
