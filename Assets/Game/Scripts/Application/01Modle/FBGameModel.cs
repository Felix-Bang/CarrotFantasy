//  Felix-Bang：FBGameModel
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
// Describe：游戏数据的读取/储存
// Createtime：2018/10/11


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FBFramework;
using System.IO;
using System;

namespace FBApplication
{
	public class FBGameModel : FBModel
	{
        #region 常量
        #endregion

        #region 事件
        #endregion

        #region 字段
        //所有关卡
        List<FBLevel> f_levels = new List<FBLevel>();
        //当前关卡索引
        int f_playLevelIndex = -1;
        //最大通关关卡索引
        int f_gameProgressIndex = -1;
        //游戏当前分数
        int f_score = 0;
        //是否游戏中
        bool f_isPlaying = false;
        #endregion

        #region 属性
        public override string Name
        {
            get { return FBConsts.M_GameModel; }
        }

        public List<FBLevel> AllLevels
        {
            get { return f_levels; }
        }

        public int LevelCount
        {
            get { return f_levels.Count; }
        }

        public bool IsPassed
        {
            get { return f_gameProgressIndex > LevelCount-1; }
        }

        public FBLevel PlayerLevel
        {
            get 
            {
                if (f_playLevelIndex < 0 || f_playLevelIndex > f_levels.Count-1)
                    throw new IndexOutOfRangeException("关卡不存在");
                else
                    return f_levels[f_playLevelIndex]; 
            }
        }

        public int Score
        {
            get { return f_score; }
            set { f_score = value; }
        }

        public bool IsPlaying
        {
            get { return f_isPlaying; }
            set { f_isPlaying = value; }
        }

        public int GameProgressIndex
        {
            get { return f_gameProgressIndex; }
        }

        public int  PlayLevelIndex
        {
            get { return f_playLevelIndex; }
            set { f_playLevelIndex = value; }
        }


        #endregion

        #region Unity回调

        #endregion

        #region 事件回调
        #endregion

        #region 方法
        //初始化
        public void OnInitialized()
        {
            //构建Level集合
            List<FileInfo> files = FBTools.GetLevelFiles();
        
            for (int i = 0; i < files.Count; i++)
            {
                FBLevel level = new FBLevel();
                FBTools.FillLevel(files[i].FullName, ref level);
                f_levels.Add(level);
            }

            //读取游戏进度
            f_gameProgressIndex = FBSaver.GetProgress();
        }

        public void StartLevel(int levelIndex)
        {
            f_playLevelIndex = levelIndex;
            f_isPlaying = true;
        }

        public void StoptLevel(bool isWin)
        {
            if (isWin && PlayLevelIndex > GameProgressIndex)
                FBSaver.SetProgress(PlayLevelIndex);

            f_isPlaying = false;
        }

        //清档
        public void ClearProgress()
        {
            f_isPlaying = false;
            f_playLevelIndex = -1;
            f_gameProgressIndex = -1;
            FBSaver.SetProgress(-1);
        }
        #endregion

        #region 帮助方法
        #endregion







    }
}

