//  Felix-Bang：FBRoundModel
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
	public class FBRoundModel : FBModel
	{

        #region 常量
        private const float f_roundInterval = 3f;  //回合之间的间隔时间 3秒
        private const float f_spawnInterval = 1f;  //两怪物出生间隔 1秒
        #endregion

        #region 字段
        private List<FBRound> f_rounds = new List<FBRound>();
        private int f_roundIndex = -1;       //当前回合的索引
        private bool f_allRoundsComplete = false;    //是否所有怪物都出来
        private Coroutine f_coroutine;
        #endregion

        #region 属性
        public override string Name
        {
            get { return FBConsts.M_RoundModel; }
        }

        /// <summary> 回合索引 </summary>
        public int RoundIndex
        {
            get { return f_roundIndex; }
        }

        /// <summary> 总回合数 </summary>
        public int RoundTotal
        {
            get { return f_rounds.Count; }
        }

        /// <summary> 所有回合是否完成 </summary>
        public bool AllRoundComplete
        {
            get { return f_allRoundsComplete; }
        }
        #endregion

        #region 方法
        public void LoadLevel(FBLevel level)
        {
            f_rounds = level.Rounds;
        }

        public void StartRound()
        {
           f_coroutine = FBGame.Instance.StartCoroutine(RunRound());
        }

        public void StopRound()
        {
            FBGame.Instance.StopCoroutine(f_coroutine);
        }

        IEnumerator RunRound()
        {
            f_roundIndex = -1;
            f_allRoundsComplete = false;

            for (int i = 0; i < f_rounds.Count; i++)
            {
                f_roundIndex = i;
                
                //回合开始
                FBRoundStartArgs e = new FBRoundStartArgs
                {
                    RoundIndex = f_roundIndex,
                    RoundTotal = RoundTotal
                };
                SendEvent(FBConsts.E_RoundStart, e);

                FBRound round = f_rounds[i];
                for (int k = 0; k < round.Count; k++)
                {
                    //出怪间隔
                    yield return new WaitForSeconds(f_spawnInterval);

                    //出怪事件
                    FBSpawnMonsterArgs spawnArgs = new FBSpawnMonsterArgs
                    {
                        MonsterID = round.MonsterID
                    };
                    SendEvent(FBConsts.E_SpawnMonster,spawnArgs);

                    if (i == f_rounds.Count -1 && k == round.Count - 1)
                        f_allRoundsComplete = true;
                }

                //回合间隔
                if(!f_allRoundsComplete)
                    yield return new WaitForSeconds(f_roundInterval);
            }
        }


        #endregion

        #region 帮助方法
        #endregion
    }
}
