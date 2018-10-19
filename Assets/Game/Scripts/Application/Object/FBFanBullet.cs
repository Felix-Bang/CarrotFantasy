//  Felix-Bang：FBFanBullet
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
// Describe：扇形子弹
// Createtime：2018/10/19

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FBApplication
{
	public class FBFanBullet : FBBullet
	{
        #region 字段
        //旋转速度（度/秒）
        public float RotateSpeed = 180f;
        #endregion

        #region 属性
        public Vector2 Direction { get; private set; }
        #endregion

        #region Unity回调
        protected override void Update()
        {
            //已爆炸跳过
            if (f_isExploded)
                return;

            //移动
            transform.Translate(Direction * Speed * Time.deltaTime, Space.World);

            //旋转
            transform.Rotate(Vector3.forward, RotateSpeed * Time.deltaTime, Space.World);

            //检测（存活/死亡）
            GameObject[] monsterObjects = GameObject.FindGameObjectsWithTag("Monster");

            foreach (GameObject monsterObject in monsterObjects)
            {
                FBMonster monster = monsterObject.GetComponent<FBMonster>();

                //忽略已死亡的怪物
                if (monster.IsDead)
                    continue;

                if (Vector3.Distance(transform.position, monster.transform.position) <= FBConsts.RangeClosedDistance)
                {
                    //敌人受伤
                    monster.Damage(this.Attack);

                    //爆炸
                    Explode();

                    //退出(重点)
                    break;
                }
            }

            //边间检测
            if (!f_isExploded && !MapRect.Contains(transform.position))
                Explode();
        }
        #endregion

        #region 方法
        public void Load(int bulletID,int level,Rect mapRect,Vector3 direction)
        {
        
            Load(bulletID, level, mapRect);
            Direction = direction;
        }
        #endregion
    }
}
