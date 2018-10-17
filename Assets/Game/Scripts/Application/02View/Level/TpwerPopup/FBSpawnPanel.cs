//  Felix-Bang：FBSpawnPanel
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
// Describe：创建炮塔
// Createtime：2018/10/16

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FBApplication
{
	public class FBSpawnPanel : MonoBehaviour
	{
        #region 字段
        FBTowerIcon[] f_icons;
        #endregion

        #region Unity回调
		void Awake () 
		{
            f_icons = GetComponentsInChildren<FBTowerIcon>();
		}
        #endregion

        #region 方法
        public void Show(FBGameModel gm, Vector3 createPosition, bool upSide)
        {
            transform.position = createPosition;
            for (int i = 0; i < f_icons.Length; i++)
            {
                FBTowerInfo info = FBGame.Instance.StaticData.GetTower(i);
                f_icons[i].Load(gm, info, createPosition, upSide);
            }
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
        #endregion

    }
}
