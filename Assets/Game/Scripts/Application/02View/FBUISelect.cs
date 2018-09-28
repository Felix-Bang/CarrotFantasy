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
// Createtime：2018/9/27


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FBFramework;

namespace FBApplication
{
	public class FBUISelect : FBView
	{
        #region 常量
        #endregion

        #region 事件
        #endregion

        #region 字段
        #endregion

        #region 属性
        public override string Name
        {
            get
            {
                return FBConsts.V_Select;
            }
        }
        #endregion

        #region 方法
        public void GoBack()
        {
            FBGame.Instance.LoadScene(1);
        }

        public void ChooseLevel()
        {
            FBStartLevelArgs e = new FBStartLevelArgs
            {
                Index = 0
            };

            SendEvent(FBConsts.E_StartLevel, e);
        }

        #endregion

        #region Unity回调
        #endregion

        #region 事件回调
        public override void HandleEvent(string eventName, object data = null)
        {
            
        }
        #endregion

        #region 帮助方法
        #endregion




    }
}

