//  Felix-Bang：FBBallBullet
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
// Describe：球形子弹
// Createtime：2018/10/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FBApplication
{
	public class FBBallBullet : FBBullet
	{
        #region 属性
        //目标
        public FBMonster Target { get; private set; }

        //移动方向
        public Vector3 Direction { get; private set; }
        #endregion

        #region Unity回调
        protected override void Update()
        {
            //已爆炸无需跟踪
            if (f_isExploded)
                return;

            //目标检测
            if (Target != null)
            {
                if (!Target.IsDead)
                {
                    //计算方向
                    Direction = (Target.transform.position - transform.position).normalized;
                }

                //角度
                LookAt();

                //移动
                transform.Translate(Direction * Speed * Time.deltaTime, Space.World);

                //打中目标
                if (Vector3.Distance(transform.position, Target.transform.position) <= FBConsts.DotClosedDistance)
                {
                    //敌人受伤
                    Target.Damage(Attack);

                    //爆炸
                    Explode();
                }
            }
            else
            {
                //移动
                transform.Translate(Direction * Speed * Time.deltaTime, Space.World);

                //边界检测
                if (!f_isExploded&& !MapRect.Contains(transform.position))
                    Explode();
            }
        }
        #endregion

        #region 方法
        public void Load(int bulletID, int level, Rect mapRect, FBMonster monster)
        {
            Load(bulletID, level, mapRect);

            Target = monster;

            //计算方向
            Direction = (Target.transform.position - transform.position).normalized;
        }
        #endregion

        #region 帮助方法
        void LookAt()
        {
            float angle = Mathf.Atan2(Direction.y, Direction.x);
            Vector3 eulerAngles = transform.eulerAngles;
            eulerAngles.z = angle * Mathf.Rad2Deg - 90;
            transform.eulerAngles = eulerAngles;
        }
        #endregion
    }
}
