//  Felix-Bang：FBSceneEnterController
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
// Describe：进入场景控制器
// Createtime：2018/9/26


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FBFramework;

namespace FBApplication
{
	public class FBSceneEnterController : FBController
	{
        public override void Execute(object data = null)
        {
            FBSceneArgs e = data as FBSceneArgs;

            //注册视图（View）
            switch (e.Index)
            {
                case 0:
                    break;
                case 1:
                    RegisterView(GameObject.Find("UIStart").GetComponent<FBUIStart>());
                    break;
                case 2:
                    RegisterView(GameObject.Find("UISelect").GetComponent<FBUISelect>());
                    break;
                case 3:
                    RegisterView(GameObject.Find("Map").transform.GetComponent<FBUISpawner>());
                    RegisterView(GameObject.Find("Canvas").transform.Find("UIBoard").GetComponent<FBUIBoard>());
                    RegisterView(GameObject.Find("Canvas").transform.Find("UICountDown").GetComponent<FBUICountDown>());
                    RegisterView(GameObject.Find("Canvas").transform.Find("UIWin").GetComponent<FBUIWin>());
                    RegisterView(GameObject.Find("Canvas").transform.Find("UILost").GetComponent<FBUILost>());
                    RegisterView(GameObject.Find("Canvas").transform.Find("UISystem").GetComponent<FBUISystem>());
                    break;
                case 4:
                    RegisterView(GameObject.Find("UIComplete").GetComponent<FBUIComplete>());
                    break;
                default:
                    break;
            }


        }


    }
}

