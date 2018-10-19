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
// Describe：瓶子炮塔
// Createtime：2018/10/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FBApplication
{
	public class FBBottle : FBTower
	{
        Transform f_shotPoint;

        protected override void Awake()
        {
            base.Awake();
            f_shotPoint = transform.Find("ShotPoint");
        }

        #region 方法
        protected override void Shot(FBMonster monster)
        {
            base.Shot(monster);

            if (f_animator.gameObject.activeSelf)
                f_animator.SetTrigger("IsAttack");

            GameObject go = FBGame.Instance.ObjectPool.Spawn("BallBullet");
            FBBallBullet bullet = go.GetComponent<FBBallBullet>();
            bullet.transform.position = f_shotPoint.position;
            bullet.Load(UseBulletID, Level, MapRect, monster);
        }

        public override void OnSpawn()
        {
            base.OnSpawn();
            f_animator.Play("Bottle_Idle");
        }

     
        #endregion
    }
}
