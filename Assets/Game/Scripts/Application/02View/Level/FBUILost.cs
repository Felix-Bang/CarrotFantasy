//  Felix-Bang：FBUILost
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
// Describe：关卡-失败
// Createtime：2018/10/09


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FBFramework;
using UnityEngine.UI;
using System;

namespace FBApplication
{
	public class FBUILost : FBView
	{
        #region 字段
        [SerializeField]
        private Text txtCurrent;
        [SerializeField]
        private Text txtTotal;
        [SerializeField]
        private Button btnRestart;
    
        #endregion

        #region 属性
        public override string Name
        {
            get
            {
                 return FBConsts.V_Lost; 
            }
        }

        #endregion

        #region Unity回调
        private void Awake()
        {
            UpdatteRoundInfo(0,0);
        }

        private void Start()
        {
            btnRestart.onClick.AddListener(OnRestartClick);          
        }

       
        #endregion

        #region 事件回调
        public override void HandleEvent(string eventName, object data = null)
        {
            
        }
        #endregion

        #region 方法
        private void OnRestartClick()
        {
            FBGameModel gameModel = GetModel<FBGameModel>();
            SendEvent(FBConsts.E_LevelStart, new FBStartLevelArgs() { ID = gameModel.PlayLevelIndex });
        }

        public void Show()
        {
            gameObject.SetActive(true);
            FBRoundModel roundModel = GetModel<FBRoundModel>();
            UpdatteRoundInfo(roundModel.RoundIndex+1,roundModel.RoundTotal);
        }

        private void Hide()
        {
            gameObject.SetActive(false);
        }

        private void UpdatteRoundInfo(int currentRound,int totalRound)
        {
            txtCurrent.text = currentRound.ToString("D2");
            txtTotal.text = totalRound.ToString();
        }

        #endregion

        #region 帮助方法
        #endregion






    }
}

