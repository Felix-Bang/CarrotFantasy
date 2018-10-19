//  Felix-Bang：FBTowerIcon
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
// Describe：炮塔Icon
// Createtime：2018/10/16

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FBApplication
{
	public class FBTowerIcon : MonoBehaviour
	{
        #region 字段
        SpriteRenderer f_render;
        FBTowerInfo f_towerInfo;
        Vector3 f_creatPos;
        bool f_enough = false;       //玩家的金币是否足够买该塔
        #endregion

        #region Unity回调
        void Awake () 
		{
            f_render = GetComponent<SpriteRenderer>();
		}
		
        private void OnMouseDown()
        {
            if (!f_enough)
                return;

            int id = f_towerInfo.ID;
            Vector3 pos = f_creatPos;
            object[] args = { id, pos };

            SendMessageUpwards("OnSpawnTower",args,SendMessageOptions.RequireReceiver);
        }
        #endregion

        #region 方法
        public void Load(FBGameModel game,FBTowerInfo info,Vector3 creatPos,bool upSide)
        {
            f_towerInfo = info;
            f_creatPos = creatPos;
            //f_enough = game.Gold > info.BasePrice;
            f_enough = true;
            string path= "Res/Roles/" + (f_enough ? info.NormalIcon : info.DisabledIcon);
            f_render.sprite = Resources.Load<Sprite>(path);

            Vector3 pos = transform.localPosition;
            pos.y = upSide ? Mathf.Abs(pos.y) : -Mathf.Abs(pos.y);
            transform.localPosition = pos;
        }
        #endregion
    }
}
