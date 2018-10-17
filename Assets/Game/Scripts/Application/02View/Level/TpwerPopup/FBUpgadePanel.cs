//  Felix-Bang：FBUpgadePanel
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
// Describe：升级/出售炮塔
// Createtime：2018/10/16

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FBApplication
{
	public class FBUpgadePanel : MonoBehaviour
	{
        #region 字段
        FBUpgradeIcon f_upgradeIcon;
        FBSellIcon f_sellIcon;
        #endregion

        #region Unity回调
        void Awake()
        {
            f_upgradeIcon = GetComponentInChildren<FBUpgradeIcon>();
            f_sellIcon = GetComponentInChildren<FBSellIcon>();
        }
        #endregion

        #region 方法
        public void Show(FBGameModel gm, FBTower tower)
        {
            transform.position = tower.transform.position;

            f_upgradeIcon.Load(gm, tower);
            f_sellIcon.Load(tower);
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
        #endregion

       
    }
}
