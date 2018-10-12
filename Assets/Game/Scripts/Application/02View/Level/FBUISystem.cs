//  Felix-Bang：FBUISystem
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
// Describe：关卡-系统
// Createtime：2018/10/09


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FBFramework;
using UnityEngine.UI;
using System;

namespace FBApplication
{
	public class FBUISystem : FBView
	{

        #region 常量
        #endregion

        #region 事件
        #endregion

        #region 
        [SerializeField]
        private Button btnResume;
        [SerializeField]
        private Button btnRestart;
        [SerializeField]
        private Button btnSelect;
        #endregion

        #region 属性
        public override string Name
        {
            get
            {
                return FBConsts.V_System;
            }
        }

        #endregion

        #region Unity回调
     

        private void Start()
        {
            btnResume.onClick.AddListener(OnResumeClick);
            btnRestart.onClick.AddListener(OnRestartClick);
            btnSelect.onClick.AddListener(OnSelectClick);
        }

      

        #endregion

        #region 事件回调
        public override void HandleEvent(string eventName, object data = null)
        {
            
        }
        #endregion

        #region 方法

        private void OnResumeClick()
        {
            throw new NotImplementedException();
        }

        private void OnRestartClick()
        {
            throw new NotImplementedException();
        }

        private void OnSelectClick()
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

    

        #endregion

        #region 帮助方法
        #endregion






    }
}

