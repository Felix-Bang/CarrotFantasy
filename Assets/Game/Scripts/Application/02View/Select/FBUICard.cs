//  Felix-Bang：FBUICard
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
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

namespace FBApplication
{
	public class FBUICard : MonoBehaviour,IPointerDownHandler
	{
        //点击事件
        public event Action<FBCard> OnClickAction;
        [SerializeField]
        private Image imgCard;
        [SerializeField]
        private Image imgLock;
        //卡片属性
        private FBCard f_card = null;
        public FBCard Card
        {
            set
            {
                f_card = value;
                BindCard();
            }
        }


        //是否为半透明
        private bool f_isTransparent;
        public bool IsTransparent
        {
            get { return f_isTransparent; }

            set
            {
                f_isTransparent = value;

                Image[] images = new Image[] { imgCard, imgLock };
                foreach (Image img in images)
                {
                    Color c = img.color;
                    c.a = value ? 0.5f : 1f;
                    img.color = c;
                }
            }
        }

        private void BindCard()
        {
            //加载图片
            string cardFile = "file://" + FBConsts.CardsDir +"\\"+ f_card.CardImage;
            StartCoroutine(FBTools.LoadImage(cardFile,imgCard));
         
            //是否锁定
            imgLock.gameObject.SetActive(f_card.IsLocked);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (OnClickAction != null)
                OnClickAction(f_card);
        }

        private void OnDestroy()
        {
            while (OnClickAction != null)
                OnClickAction -= OnClickAction;
        }
    }
}

