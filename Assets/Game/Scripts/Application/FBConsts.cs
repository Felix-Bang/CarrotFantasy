//  Felix-Bang：Consts
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
       

        //存档

        //Model

        //View
        public const string V_Start = "V_Start";
        public const string V_Select = "V_Select";
        public const string V_Board = "V_Board";
        public const string V_CountDown = "V_CountDown";
        public const string V_Win = "V_Win";
        public const string V_Lost = "V_Lost";
        public const string V_System = "V_System";

        //Control
        /// <summary> 启动游戏 </summary>
        public const string E_StartUp = "E_StartUp";

        /// <summary> 进入场景 </summary>
        public const string E_EnterScene = "E_EnterScene";
        /// <summary> 退出场景 </summary>
        public const string E_ExitScene = "E_ExitScene";

        /// <summary> 开始关卡 </summary>
        public const string E_StartLevel = " E_StartLevel";
        /// <summary> 结束关卡 </summary>
        public const string E_EndLevel = "E_EndLevel";

        /// <summary> 结束倒计时 </summary>
        public const string E_CountDownComplete = "E_CountDownComplete";

        

        
    }

    public enum GameSpeed
    {
        One,
        Two
    }
}

