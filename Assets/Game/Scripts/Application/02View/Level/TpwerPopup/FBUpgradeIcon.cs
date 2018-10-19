//  Felix-Bang：FBUpgradeIcon
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
// Describe：升级Icon
// Createtime：2018/10/16

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FBApplication
{
	public class FBUpgradeIcon : MonoBehaviour
	{
        #region 字段
        SpriteRenderer f_render;
        FBTower f_tower;
        #endregion


        #region Unity回调
		void Awake () 
		{
            f_render = GetComponent<SpriteRenderer>();
		}

        void OnMouseDown()
        {
            if (f_tower.IsTopLevel)
                return;

            SendMessageUpwards("OnUpgradeTower", f_tower, SendMessageOptions.RequireReceiver);
        }
        #endregion

        #region 方法
        public void Load(FBGameModel game, FBTower tower)
        {
            f_tower = tower;

            FBTowerInfo info = FBGame.Instance.StaticData.GetTower(tower.ID);
            string path = "Res/Roles/" + (tower.IsTopLevel ? info.NormalIcon : info.DisabledIcon);
            f_render.sprite = Resources.Load<Sprite>(path);
        }
        #endregion
    }
}
