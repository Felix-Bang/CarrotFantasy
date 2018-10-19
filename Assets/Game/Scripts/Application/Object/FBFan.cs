//  Felix-Bang：FBFan
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
// Describe：风扇炮塔
// Createtime：2018/10/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FBApplication
{
	public class FBFan : FBTower
    {
        private int f_bulletCount = 6;

        protected override void Shot(FBMonster monster)
        {
            base.Shot(monster);
            for (int i = 0; i < f_bulletCount; i++)
            {
                float radians = (Mathf.PI * 2f / f_bulletCount) * i;
                Vector3 dir = new Vector3(Mathf.Cos(radians), Mathf.Sin(radians), 0f);

                //产生子弹
                GameObject go = FBGame.Instance.ObjectPool.Spawn("FanBullet");
                FBFanBullet bullet = go.GetComponent<FBFanBullet>();
                bullet.transform.position = transform.position;//中心点
                bullet.Load(this.UseBulletID, this.Level, this.MapRect, dir);

            }
        }
	}
}
