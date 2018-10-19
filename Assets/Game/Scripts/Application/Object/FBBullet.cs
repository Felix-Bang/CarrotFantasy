//  Felix-Bang：FBBullet
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

namespace FBApplication
{
	public abstract class FBBullet : FBReusableObject, IFBReusable
    {
        #region 字段
       /// <summary> 类型 </summary>
        public int ID { get; private set; }
        /// <summary> 等级 </summary>
        public int Level { get; set; }
        /// <summary> 基本速度 </summary>
        public float BaseSpeed { get; private set; }
        /// <summary> 基本攻击力 </summary>
        public int BaseAttack { get; private set; }
        /// <summary> 移动速度 </summary>
        public float Speed { get { return BaseSpeed * Level; } }
        /// <summary> 攻击力 </summary>
        public int Attack { get { return BaseAttack * Level; } }
        /// <summary> 地图范围 </summary>
        public Rect MapRect { get; private set; }
        /// <summary> 延迟回收时间(秒) </summary>
        public float DelayToDestory = 1f;
        /// <summary> 是否爆炸 </summary>
        protected bool f_isExploded = false;
        /// <summary>动画组件 </summary>
        Animator f_animator;

        #endregion

        #region 属性
        #endregion

        #region Unity回调
        protected virtual void Awake()
        {
            //f_animator = GetComponent<Animator>();
        }

        protected virtual void Update()
        {

        }

        #endregion

        #region 事件回调
        #endregion

        #region 方法
        public void Load(int bulletID, int level, Rect mapRect)
        {
            MapRect = mapRect;

            ID = bulletID;
            Level = level;

            FBBulletInfo info = FBGame.Instance.StaticData.GetBullet(bulletID);
            BaseSpeed = info.BaseSpeed;
            BaseAttack = info.BaseAttack;
        }

        public void Explode()
        {
            //标记已爆炸
            f_isExploded = true;

            //播放爆炸动画
            Debug.Log(f_animator);
            f_animator.SetTrigger("IsExplode");

            //延迟回收
            StartCoroutine("DestoryCoroutine");
        }


        public override void OnSpawn()
        {
            f_animator = GetComponent<Animator>();
        }

        public override void OnUnspawn()
        {
            f_isExploded = false;

            f_animator.Play("Play");
            f_animator.ResetTrigger("IsExplode");
        }
        #endregion

        #region 帮助方法
        IEnumerator DestoryCoroutine()
        {
            //延迟
            yield return new WaitForSeconds(DelayToDestory);

            //回收
            FBGame.Instance.ObjectPool.Unspawn(this.gameObject);
        }


        #endregion
    }
}
