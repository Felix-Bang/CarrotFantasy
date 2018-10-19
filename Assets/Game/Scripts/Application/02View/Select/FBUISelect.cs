//  Felix-Bang：FBUISelect
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
// Describe：选择界面
// Createtime：2018/10/09


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FBFramework;
using System.IO;
using System;

namespace FBApplication
{
	public class FBUISelect : FBView
	{
        #region 字段
        [SerializeField]
        private Button btnBack;
        [SerializeField]
        private Button btnHelp;
        [SerializeField]
        private Button btnStart;
        [SerializeField]
        private FBUICard f_leftCard;
        [SerializeField]
        private FBUICard f_currentCard;
        [SerializeField]
        private FBUICard f_rightCard;

        private List<FBCard> f_cards = new List<FBCard>();
        private int f_selectedIndex = -1;
        FBGameModel f_gameModel = null;
        #endregion

        #region 属性
        public override string Name
        {
            get { return FBConsts.V_Select; }
        }
        #endregion

        #region 方法
        private void OnBackButtonClick()
        {
            FBGame.Instance.LoadScene(1);
        }

        private void OnHelpButtonClick()
        {
            Debug.Log("Help");
        }

        private void OnStartButtonClick()
        {
            FBStartLevelArgs e = new FBStartLevelArgs
            {
                ID = f_selectedIndex
            };

            SendEvent(FBConsts.E_LevelStart, e);
        }

        //public void ChooseLevel()
        //{
        //    FBStartLevelArgs e = new FBStartLevelArgs
        //    {
        //        ID = f_selectedIndex
        //    };

        //    SendEvent(FBConsts.E_LevelStart, e);
        //}

        private void LoadCards()
        {
            //获取Level集合
            List<FBLevel> levels = f_gameModel.AllLevels;

            //构建Card合集
            for (int i = 0; i < levels.Count; i++)
            {
                FBCard card = new FBCard()
                {
                    LevelID = i,
                    CardImage = levels[i].CardImage,
                    IsLocked = !(i <= f_gameModel.GameProgressIndex +1) //TODO
                    
                };

                f_cards.Add(card);
            }

            f_leftCard.OnClickAction += (info)=>SelectCard(info.LevelID);
            f_currentCard.OnClickAction += (info) => SelectCard(info.LevelID);
            f_rightCard.OnClickAction += (info) => SelectCard(info.LevelID);

            //默认选择第一个关卡
            SelectCard(0);
        }

        //选择关卡
        private void SelectCard(int index)
        {
            if (f_selectedIndex == index)
                return;

            f_selectedIndex = index;
            //计算索引
            int leftIndex = f_selectedIndex - 1;
            int currentIndex = f_selectedIndex;
            int rightIndex = f_selectedIndex + 1;

            //绑定数据
            if (leftIndex < 0)
                f_leftCard.gameObject.SetActive(false);
            else
            {
                f_leftCard.gameObject.SetActive(true);
                f_leftCard.IsTransparent = true;
                f_leftCard.Card = f_cards[leftIndex];
            }

            f_currentCard.IsTransparent = false;
            f_currentCard.Card = f_cards[currentIndex];
            //开始按钮显示设置
            btnStart.gameObject.SetActive(!f_cards[currentIndex].IsLocked);


            if (rightIndex >= f_cards.Count)
                f_rightCard.gameObject.SetActive(false);
            else
            {
                f_rightCard.gameObject.SetActive(true);
                f_rightCard.IsTransparent = true;
                f_rightCard.Card = f_cards[rightIndex];
            }
        }

        #endregion

        #region Unity回调
        private void Start()
        {
            btnBack.onClick.AddListener(OnBackButtonClick);
            btnHelp.onClick.AddListener(OnHelpButtonClick);
            btnStart.onClick.AddListener(OnStartButtonClick);
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
                    FBSceneArgs e = data as FBSceneArgs;
                    if (e.Index == 2)
                    {
                        f_gameModel = GetModel<FBGameModel>();
                        LoadCards();
                    }
                    break;
            }
        }
        #endregion

        #region 帮助方法
        #endregion




    }
}

