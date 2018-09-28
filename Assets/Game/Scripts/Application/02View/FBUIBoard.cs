//  Felix-Bang：FBUIBoard
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
// Describe：关卡-公告栏
// Createtime：2018/9/28


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FBFramework;
using UnityEngine.UI;
using System;

namespace FBApplication
{
	public class FBUIBoard : FBView
	{
        #region 常量
        #endregion

        #region 事件
        #endregion

        #region 字段
        [SerializeField]
        private Text txtScore;
        [SerializeField]
        private Text txtCurrent;
        [SerializeField]
        private Text txtTotal;
        [SerializeField]
        private GameObject goRoundInfo;
        [SerializeField]
        private GameObject goPause;
        [SerializeField]
        private Button btnSpeed1;
        [SerializeField]
        private Button btnSpeed2;
        [SerializeField]
        private Button btnPause;
        [SerializeField]
        private Button btnPlay;
        [SerializeField]
        private Button btnSystem;

        private GameSpeed f_speed = GameSpeed.One;
        private bool f_isPlaying = false;
        private int f_gold = 0;
        #endregion

        #region 属性
        public override string Name
        {
            get { return FBConsts.V_Board; }
        }

        public int Glod
        {
            get { return f_gold; }
            set
            {
                f_gold = value;

                txtScore.text = value.ToString();
            }
        }

        public GameSpeed Speed
        {
            get { return f_speed; }
            set
            {
                f_speed = value;

                btnSpeed1.gameObject.SetActive(f_speed == GameSpeed.One);
                btnSpeed2.gameObject.SetActive(f_speed == GameSpeed.Two);
            }
        }

        public bool IsPlaying
        {
            get { return f_isPlaying; }
            set
            {
                f_isPlaying = value;
                goRoundInfo.SetActive(value);
                goPause.SetActive(!value);
            }
        }

        #endregion

        #region Unity回调
        private void Awake()
        {
            Glod = 0;
            IsPlaying = true;
            Speed = GameSpeed.One;
        }

        private void Start()
        {
            btnSpeed1.onClick.AddListener(OnSpeed1Click);
            btnSpeed2.onClick.AddListener(OnSpeed2Click);
            btnPause.onClick.AddListener(OnPauseClick);
            btnPlay.onClick.AddListener(OnPlayClick);
            btnSystem.onClick.AddListener(OnSystemClick);
        }
        #endregion

        #region 事件回调
        public override void HandleEvent(string eventName, object data = null)
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region 方法
        private void OnSpeed1Click()
        {
            Speed = GameSpeed.Two;
        }

        private void OnSpeed2Click()
        {
            Debug.Log("Two");
            Speed = GameSpeed.One;
        }

        private void OnPauseClick()
        {
            IsPlaying = false;
        }

        private void OnPlayClick()
        {
            IsPlaying = false;
        }

        private void OnSystemClick()
        {
            throw new NotImplementedException();
        }

        private void UpdateRoundInfo(int currentRound,int total)
        {
            txtCurrent.text = currentRound.ToString("D2");
            txtTotal.text = total.ToString("D2");
        }

        #endregion

        #region 帮助方法
        #endregion






    }
}

