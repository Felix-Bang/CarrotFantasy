//  Felix-Bang：FBUITowerPopup
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
// Describe：炮塔管理界面
// Createtime：2018/10/16

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FBFramework;

namespace FBApplication
{
	public class FBUITowerPopup : FBView
	{
        #region 字段
        [SerializeField]
        private FBSpawnPanel f_spawnPanel;
        [SerializeField]
        private FBUpgadePanel f_upgadePanel;
        #endregion

        #region 属性
        private static FBUITowerPopup f_Instance = null;
        public static FBUITowerPopup Instance
        {
            get
            {
                return f_Instance;
            }
        }

        public override string Name
        {
            get { return FBConsts.V_TowerPopup; }
        }

        public bool IsPopShow
        {
            get
            {
                foreach (Transform child in transform)
                {
                    if (child.gameObject.activeSelf)
                        return true;
                }
                return false;
            }
        }
        #endregion

        #region 事件回调
        void Awake()
        {
            f_Instance = this;
        }

        void Start()
        {
            HideAllPanels();
        }


        public override void RegisterEvents()
        {
            EventLists.Add(FBConsts.E_ShowTowerCreat);
            EventLists.Add(FBConsts.E_ShowTowerUpgrade);
            EventLists.Add(FBConsts.E_TowerHide);
        }

        public override void HandleEvent(string eventName, object data = null)
        {
            switch (eventName)
            {
                case FBConsts.E_ShowTowerCreat:
                    ShowCreatePanel(data as FBShowTowerCreatArgs);
                    break;
                case FBConsts.E_ShowTowerUpgrade:
                    ShowUpgradePanel(data as FBShowTowerUpgradeArgs);
                    break;
                case FBConsts.E_TowerHide:
                    HideAllPanels();
                    break;
            }
        }

        void OnSpawnTower(object[] args)
        {
            SendEvent(FBConsts.E_SpawnTower,new FBSpawnTowerArgs() { TowerID =(int)args[0],Position=(Vector3)args[1]});       
        }

        void OnUpgradeTower(FBTower tower)
        {
            SendEvent(FBConsts.E_UpgradeTower, new FBUpgradeTowerArgs() { Tower = tower });
        }

        void OnSellTower(FBTower tower)
        {
            SendEvent(FBConsts.E_SellTower, new FBSellTowerArgs() { Tower = tower });
        }

        #endregion

        #region 方法
        void ShowCreatePanel(FBShowTowerCreatArgs args)
        {
            HideAllPanels();
            FBGameModel gm = GetModel<FBGameModel>();
            f_spawnPanel.Show(gm, args.Position, args.UpSide);
        }

        void ShowUpgradePanel(FBShowTowerUpgradeArgs args)
        {
            HideAllPanels();
            FBGameModel gm = GetModel<FBGameModel>();
            f_upgadePanel.Show(gm, args.Tower);
        }

        void HideAllPanels()
        {
            f_spawnPanel.Hide();
            f_upgadePanel.Hide();
        }
        #endregion      
    }
}
