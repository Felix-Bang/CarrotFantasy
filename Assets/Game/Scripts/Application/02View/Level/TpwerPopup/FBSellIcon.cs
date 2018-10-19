//  Felix-Bang：FBSellIcon
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
// Describe：出售Icon
// Createtime：2018/10/16

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FBApplication
{
	public class FBSellIcon : MonoBehaviour
	{
        #region 字段
        FBTower f_tower;
        #endregion

        #region Unity回调
        private void OnMouseDown()
        {
            SendMessageUpwards("OnSellTower", f_tower, SendMessageOptions.RequireReceiver);
        }
        #endregion

        #region 方法
        public void Load(FBTower tower)
        {
            f_tower = tower;
        }
        #endregion

    }
}
