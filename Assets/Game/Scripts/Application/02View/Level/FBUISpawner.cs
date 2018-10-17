//  Felix-Bang：FBUISpawner
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
// Describe：怪物孵化器
// Createtime：2018/10/12

using FBFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FBApplication
{
	public class FBUISpawner : FBView
	{
        #region 字段
        FBMap f_map;
        FBCarrot f_carrot = null;
        #endregion

        #region 属性
        public override string Name
        {
            get
            {
                return FBConsts.V_Spawner;
            }
        }

        #endregion

 

        #region 事件回调
        public override void RegisterEvents()
        {
            EventLists.Add(FBConsts.E_SceneEnter);
            EventLists.Add(FBConsts.E_SpawnMonster);
            EventLists.Add(FBConsts.E_SpawnTower);
        }

        public override void HandleEvent(string eventName, object data = null)
        {
            switch (eventName)
            {
                case FBConsts.E_SceneEnter:
                    OnSpawnCarrot(data as FBSceneArgs);
                    break;
                case FBConsts.E_SpawnMonster:
                    OnSpawnMonster(data as FBSpawnMonsterArgs);
                    break;
                case FBConsts.E_SpawnTower:
                    OnSpawnTower(data as FBSpawnTowerArgs);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 方法
        private void OnSpawnCarrot(FBSceneArgs args)
        {
            if (args.Index == 3)
            {
                //获取数据
                FBGameModel gameModel = GetModel<FBGameModel>();
                //加载地图
                f_map = GetComponent<FBMap>();
                f_map.OnFBGridClick += OnMapGridClick;
                f_map.LoadLevel(gameModel.PlayLevel);
            }

            GameObject go = FBGame.Instance.ObjectPool.Spawn("Carrot");
            f_carrot = go.GetComponent<FBCarrot>();
            f_carrot.transform.position = f_map.Path[f_map.Path.Length - 1];
            f_carrot.DeadAction += CarrotDead;
        }

        private void OnMapGridClick(object sender, FBGridClickEventArgs e)
        {           
            FBGameModel game = GetModel<FBGameModel>();
            FBGrid grid = e.Grid;
            if (game.IsPlaying && grid.CanHold)
            {              
                if (grid.Data == null)
                {                 
                    FBShowTowerCreatArgs args = new FBShowTowerCreatArgs()
                    {
                        Position = f_map.GetPosition(grid),
                        UpSide = grid.Index_Y < FBMap.RowCount / 2
                    };
                    SendEvent(FBConsts.E_ShowTowerCreat,args);
                }
                else
                {
                    Debug.Log("Click Map05");
                    FBTower tower = grid.Data as FBTower;
                    FBShowTowerUpgradeArgs args = new FBShowTowerUpgradeArgs() { Tower = tower };
                    SendEvent(FBConsts.E_ShowTowerUpgrade, args);
                }

            }
        }

        private void OnSpawnMonster(FBSpawnMonsterArgs args)
        {
            //创建怪物
            string monsterName = "Monster" + args.MonsterID;
       
            GameObject go= FBGame.Instance.ObjectPool.Spawn(monsterName);
            FBMonster monster = go.GetComponent<FBMonster>();

            monster.HPChangedAction += MonsterHPChanged;
            monster.DeadAction += MonsterDead;
            monster.ReachedAction += MonSterReched;
                
            monster.OnLoad(f_map.Path);
        }

        private void OnSpawnTower(FBSpawnTowerArgs args)
        {
            //创建Tower
            FBTowerInfo info = FBGame.Instance.StaticData.GetTower(args.TowerID);
            GameObject go = FBGame.Instance.ObjectPool.Spawn(info.PrefabName);
            //go.transform.position = args.Position;
            FBTower tower = go.GetComponent<FBTower>();
            tower.transform.position = args.Position;

            //Tile里放入Tower信息
            FBGrid tile = f_map.GetGrid(args.Position);
            //tile.Data = tower;

            ////初始化Tower
            tower.Load(args.TowerID, tile);
        }


        private void MonsterHPChanged(int arg1, int arg2)
        {

        }

        private void MonSterReched(FBMonster monster)
        {
            //萝卜掉血
            f_carrot.Damage(1);
            //怪物死亡
            monster.HP = 0;
        }

        private void MonsterDead(FBRole monster)
        {
            //回收
            FBGame.Instance.ObjectPool.Unspawn(monster.gameObject);

            GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");
            FBRoundModel roundModel = GetModel<FBRoundModel>();
           
            //  萝卜没死             场景上已没有怪物           所有怪物已出完
            if (!f_carrot.IsDead && monsters.Length <= 0 && roundModel.AllRoundComplete)
            {
                FBGameModel gameModel = GetModel<FBGameModel>();
                //游戏胜利
                SendEvent(FBConsts.E_LevelEnd,new FBEndLevelArgs() { ID = gameModel.PlayLevelIndex,IsWin=true });
            }
        }

        private void CarrotDead(FBRole carrot)
        {
            FBGame.Instance.ObjectPool.Unspawn(carrot.gameObject);

            FBGameModel gameModel = GetModel<FBGameModel>();
            SendEvent(FBConsts.E_LevelEnd, new FBEndLevelArgs() { ID = gameModel.PlayLevelIndex, IsWin = false });
        }

        #endregion

        #region 帮助方法
        #endregion
    }
}
