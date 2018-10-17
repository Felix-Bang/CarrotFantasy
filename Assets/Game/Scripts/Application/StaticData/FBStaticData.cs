//  Felix-Bang：FBStaticData
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
// Describe：静态数据
// Createtime：2018/9/26


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FBFramework;
using System;

namespace FBApplication
{
	public class FBStaticData :FBSingleton<FBStaticData>
	{
        Dictionary<int, FBCarrotInfo> f_carrots_dic = new Dictionary<int, FBCarrotInfo>();
        Dictionary<int, FBMonsterInfo> f_monsters_dic = new Dictionary<int, FBMonsterInfo>();
        Dictionary<int, FBTowerInfo> f_towers_dic = new Dictionary<int, FBTowerInfo>();
        //Dictionary<int, BulletInfo> m_Bullets = new Dictionary<int, BulletInfo>();

        protected override void Awake()
        {
            base.Awake();
            OnInitializeCarrots();
            OnInitializeMonsters();
            OnInitializeTowers();
            OnInitializeBullets();
        }

        private void OnInitializeCarrots()
        {
            f_carrots_dic.Add(0, new FBCarrotInfo() { ID = 0, HP = 4 });
        }

        private void OnInitializeMonsters()
        {
            f_monsters_dic.Add(0, new FBMonsterInfo() { ID = 0, HP = 1, Speed = 3f });
            f_monsters_dic.Add(1, new FBMonsterInfo() { ID = 1, HP = 2, Speed = 3f });
            f_monsters_dic.Add(2, new FBMonsterInfo() { ID = 2, HP = 5, Speed = 3f });
            f_monsters_dic.Add(3, new FBMonsterInfo() { ID = 3, HP = 10, Speed = 1f });
            f_monsters_dic.Add(4, new FBMonsterInfo() { ID = 4, HP = 10, Speed = 1f });
            f_monsters_dic.Add(5, new FBMonsterInfo() { ID = 5, HP = 100, Speed = 0.5f });
        }

        private void OnInitializeTowers()
        {
            f_towers_dic.Add(0, new FBTowerInfo() { ID = 0, PrefabName = "Bottle", NormalIcon = "Bottle/Bottle01", DisabledIcon = "Bottle/Bottle00", MaxLevel = 3, BasePrice = 1, ShotRate = 2, GuardRange = 3f, UseBulletID = 0 });
            f_towers_dic.Add(1, new FBTowerInfo() { ID = 1, PrefabName = "Fan", NormalIcon = "Fan/Fan01", DisabledIcon = "Fan/Fan00", MaxLevel = 3, BasePrice = 2, ShotRate = 1, GuardRange = 3f, UseBulletID = 1 });
        }

        private void OnInitializeBullets()
        {
            
        }

        public FBCarrotInfo GetCarrot()
        {
            return f_carrots_dic[0];
        }

        public FBMonsterInfo GetMoster(MonsterType mosterID)
        {
            return f_monsters_dic[(int)mosterID];
        }

        public FBTowerInfo GetTower(int towerID)
        {
            return f_towers_dic[towerID];
        }

    }
}

