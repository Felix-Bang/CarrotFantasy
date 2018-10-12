﻿//  Felix-Bang：Consts
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
// Describe：常量
// Createtime：2018/9/20


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FBApplication
{
	public static class FBConsts
	{
        //目录
        public static readonly string LevelDir = Application.dataPath + @"/Resources/Res/Levels";
        public static readonly string MpsDir = Application.dataPath + @"/Resources/Res/Maps";
        public static readonly string CardsDir = Application.dataPath + @"/Resources/Res/Cards";

        //存档
        public const string GameProgress = "GameProgress";

        //Model
        public const string M_GameModel = "M_GameModel";


        //View
        public const string V_Start = "V_Start";
        public const string V_Select = "V_Select";
        public const string V_Board = "V_Board";
        public const string V_CountDown = "V_CountDown";
        public const string V_Win = "V_Win";
        public const string V_Lost = "V_Lost";
        public const string V_System = "V_System";
        public const string V_Complete = "V_Complete";

        //Control
        /// <summary> 启动游戏 </summary>
        public const string E_StartUp = "E_StartUp";

        /// <summary> 进入场景 </summary>
        public const string E_SceneEnter = "E_SceneEnter";
        /// <summary> 退出场景 </summary>
        public const string E_SceneExit = "E_SceneExit";

        /// <summary> 开始关卡 </summary>
        public const string E_LevelStart = "E_LevelStart";
        /// <summary> 结束关卡 </summary>
        public const string E_LevelEnd = "E_LevelEnd";

        /// <summary> 结束倒计时 </summary>
        public const string E_CountDownComplete = "E_CountDownComplete";

        

        
    }

    public enum GameSpeed
    {
        One,
        Two
    }
}

