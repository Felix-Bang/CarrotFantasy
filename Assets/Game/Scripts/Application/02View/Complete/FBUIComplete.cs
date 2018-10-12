//  Felix-Bang：FBUIComplete
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
// Describe：通关
// Createtime：2018/10/09


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FBFramework;
using UnityEngine.UI;
using System;

namespace FBApplication
{
	public class FBUIComplete : FBView
	{

        #region 常量
        #endregion

        #region 事件
        #endregion

        #region 
        [SerializeField]
        private Button btnRestart;
        [SerializeField]
        private Button btnClear;
        #endregion

        #region 属性
        public override string Name
        {
            get
            {
                return FBConsts.V_Complete;
            }
        }

        #endregion

        #region Unity回调
     

        private void Start()
        {
            
            btnRestart.onClick.AddListener(OnRestartClick);
            btnClear.onClick.AddListener(OnClearClick);
        }



        #endregion

        #region 事件回调
        public override void RegisterEvents()
        {
            base.RegisterEvents();
        }

        public override void HandleEvent(string eventName, object data = null)
        {
            
        }
        #endregion

        #region 方法

        private void OnRestartClick()
        {
            FBGame.Instance.LoadScene(1);
        }

        private void OnClearClick()
        {
            Debug.Log("清空数据");
        }
        #endregion

        #region 帮助方法
        #endregion






    }
}

