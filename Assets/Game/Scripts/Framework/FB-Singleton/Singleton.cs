//  Felix-Bang：Singleton
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
// Describe：单例模式
// Createtime：2018/9/18


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FelixFramework
{
	public abstract class Singleton<T> : MonoBehaviour
        where T:MonoBehaviour
	{
        private static T f_instance=null;
        public static T Inatance
        {
            get { return f_instance; }
        }
		
		protected virtual void Awake()
		{
            f_instance = this as T;
		}
	}
}

