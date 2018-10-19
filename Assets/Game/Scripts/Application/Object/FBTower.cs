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
        [SerializeField] int f_level = 0;
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
                transform.localScale = Vector3.one * (f_level);
            }
        }
        public bool IsTopLevel { get { return Level >= MaxLevel; } }
        public float ShotRate { get; private set; }
        public float GuardRange { get; private set; }
        private int BasePrice { get; set; }
        public int UseBulletID { get; set; }
        public int Price { get { return BasePrice * Level; } }
        public Rect MapRect { get; private set; }
        #endregion

        #region Unity回调
        protected virtual void Awake()
        {
            f_animator = GetComponent<Animator>();
        }

        void Update()
        {
            //转向目标
            if (f_target == null)
            {
                GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");
               
                foreach (GameObject m in monsters)
                {
                    FBMonster monster = m.GetComponent<FBMonster>();
                    float dis = Vector3.Distance(transform.position, monster.transform.position);
                    if (!monster.IsDead && dis <= GuardRange)
                    {
                        f_target = monster;
                        break;
                    }
                }

                LookAt(f_target);
            }
            else
            {
                float dis = Vector3.Distance(transform.position, f_target.transform.position);
                if (f_target.IsDead && dis > GuardRange)
                {
                    f_target = null;
                    LookAt(f_target);
                }
                else
                {
                    LookAt(f_target);

                    float attackTime = f_lastShotTime + 1f / ShotRate;
                    if (Time.time >= attackTime)
                    {
                        Shot(f_target);
                        f_lastShotTime = Time.time;
                    }
                }
            }
        }
        #endregion


        #region 方法
        public void Load(int towerId, FBGrid grid, Rect mapRect)
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
            MapRect = mapRect;
        }

        protected virtual void Shot(FBMonster monster)
        {
            if (f_animator.gameObject.activeSelf)
                f_animator.SetTrigger("IsAttack");
        }


        public override void OnSpawn()
        {
            f_animator = GetComponent<Animator>();
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

            f_grid = null;
        }
        #endregion

        #region 帮助方法
        private void LookAt(FBMonster target)
        {
            if (target != null)
            {
                Vector3 dir = (f_target.transform.position - transform.position).normalized;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                Vector3 eulerAnglles = transform.eulerAngles;
                eulerAnglles.z = angle - 90f;
                transform.eulerAngles = eulerAnglles;
            }
            else
            {
                Vector3 eulerAnglles = transform.eulerAngles;
                eulerAnglles.z = 0;
                transform.eulerAngles = eulerAnglles;
            }
        }
        #endregion
    }
}
