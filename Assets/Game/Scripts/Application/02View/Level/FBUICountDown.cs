//  Felix-Bang：FBUICountDown
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
// Describe：关卡-倒计时
// Createtime：2018/9/28


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FBFramework;
using UnityEngine.UI;
using System;

namespace FBApplication
{
	public class FBUICountDown : FBView
	{
        #region 字段
        [SerializeField]
        private Image imgCount;
        [SerializeField]
        private Sprite[] sptNumbers;
        #endregion

        #region 属性
        public override string Name
        {
            get { return FBConsts.V_CountDown; }
        }
        #endregion

        #region 事件回调
        public override void RegisterEvents()
        {
            EventLists.Add(FBConsts.E_SceneEnter);
        }

        public override void HandleEvent(string eventName, object data = null)
        {
            switch (eventName)
            {
                case FBConsts.E_SceneEnter:
                    FBSceneArgs e = (FBSceneArgs)data;
                    if (e.Index == 3)
                        StartCountDown();
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 方法
        private void Show()
        {
            gameObject.SetActive(true);
        }

        private void Hide()
        {
            gameObject.SetActive(false);
        }

        public void StartCountDown()
        {
            Show();
            StartCoroutine("DisplayCount");
        }

        IEnumerator DisplayCount()
        {
            int count = 3;
            while (count > 0)
            {
                imgCount.sprite = sptNumbers[count - 1];
                count--;
                yield return new WaitForSeconds(1f);

                if (count <= 0)
                    break;
            }

            Hide();

            SendEvent(FBConsts.E_CountDownComplete);
        }

        #endregion
    }
}

