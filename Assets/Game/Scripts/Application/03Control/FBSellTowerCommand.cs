//  Felix-Bang：FBSellTowerCommand
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
// Describe：
// Createtime：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FBFramework;

namespace FBApplication
{
	public class FBSellTowerCommand : FBController
	{
        public override void Execute(object data = null)
        {
            //FBSellTowerArgs e = data as FBSellTowerArgs;
            //FBTower tower = e.Tower;

            ////清除Tile存储的信息
            //tower.Tile.Data = null;

            ////半价出售
            //FBGameModel gm = GetModel<FBGameModel>();
            //gm.Gold += e.Tower.Price / 2;

            ////回收
            //FBGame.Instance.ObjectPool.Unspawn(e.Tower.gameObject);
        }
	}
}
