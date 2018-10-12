//  Felix-Bang：FBUIWin
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
// Describe：关卡-获胜
// Createtime：2018/10/09


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FBFramework;
using UnityEngine.UI;
using System;

namespace FBApplication
{
	public class FBUIWin : FBView
	{

        #region 常量
        #endregion

        #region 事件
        #endregion

        #region 字段
        [SerializeField]
        private Text txtCurrent;
        [SerializeField]
        private Text txtTotal;
        [SerializeField]
        private Button btnRestart;
        [SerializeField]
        private Button btnContinute;
        #endregion

        #region 属性
        public override string Name
        {
            get
            {
                 return FBConsts.V_Win; 
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
            btnContinute.onClick.AddListener(OnContinuteClick);
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
            throw new NotImplementedException();
        }

        private void OnContinuteClick()
        {
            throw new NotImplementedException();
        }

        private void Show()
        {
            gameObject.SetActive(true);
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

