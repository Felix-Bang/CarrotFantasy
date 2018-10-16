//  Felix-Bang：FBMonster
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
// Describe：怪物
// Createtime：2018/10/15

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FBApplication
{
	public class FBMonster : FBRole
	{
        #region 常量
        public const float CLOSEDDISTANCE = 0.1f;
        #endregion

        #region 事件
        public event Action<FBMonster> ReachedAction;
        #endregion

        #region 字段
        
        [SerializeField]
        MonsterType f_type = MonsterType.Monster0;
        float f_moveSpeed;               //移动速度
        Vector3[] f_path=null;           //路径拐点
        int f_pathIndex = -1;            //下一拐点索引
        bool f_isReached = false;        //是否到达终点

        #endregion

        #region 属性
        public float MoveSpeed
        {
            get { return f_moveSpeed; }
            set
            {
                f_moveSpeed = value;
            }
        }
        #endregion

        #region Unity回调
		void Update ()
		{
            if (f_isReached)
                return;

            Vector3 pos = transform.position;
            Vector3 dest = f_path[f_pathIndex + 1];
            float dis = Vector3.Distance(pos,dest);

            if (dis < CLOSEDDISTANCE)
            {
                MoveTo(dest);

                if (HasNext())
                    MoveNext();
                else
                {
                    f_isReached = true;

                    //触发到达终点的事件
                    if (ReachedAction != null)
                        ReachedAction(this);
                }
            }
            else
            {
                Vector3 direction = (dest - pos).normalized;
                transform.Translate(direction * f_moveSpeed * Time.deltaTime);
            }
		}
        #endregion

        #region 事件回调
        public override void OnSpawn()
        {
            base.OnSpawn();
            FBMonsterInfo info = FBGame.Instance.StaticData.GetMoster(f_type);
            MaxHP = info.HP;
            HP = info.HP;
            MoveSpeed = info.Speed;
        }

        public override void OnUnspawn()
        {
            base.OnUnspawn();
            f_moveSpeed = 0;
            f_path = null;  
            f_pathIndex = -1;   
            f_isReached = false; 

            while (ReachedAction != null)
                ReachedAction -= ReachedAction;
        }
        #endregion

        #region 方法
        public void OnLoad(Vector3[] path)
        {
            f_path = path;
            MoveNext();
        }

        private bool HasNext()
        {
            return f_pathIndex + 1 < f_path.Length - 1;
        }

        private void MoveNext()
        {
            if (!HasNext())
                return;

            if (f_pathIndex == -1)
            {
                f_pathIndex = 0;
                MoveTo(f_path[f_pathIndex]);
            }
            else
                f_pathIndex++;
        }

        private void MoveTo(Vector3 position)
        {
            transform.position = position;
        }


        #endregion

        #region 帮助方法
        #endregion
    }
}
