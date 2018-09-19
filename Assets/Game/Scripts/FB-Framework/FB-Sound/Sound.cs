//  Felix-Bang：Sound
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

namespace FBFramework
{
    public class Sound : Singleton<Sound>
    {
        public string ResourceDir = "";
        AudioSource f_bgm;
        AudioSource f_effectSound;

        public float BgmVolum
        {
            get { return f_bgm.volume; }
            set { f_bgm.volume = value; }
        }

        public float EffectVolum
        {
            get { return f_effectSound.volume; }
            set { f_effectSound.volume = value; }
        }

        protected override void Awake()
        {
            base.Awake();

            f_bgm = this.gameObject.AddComponent<AudioSource>();
            f_bgm.playOnAwake = true;
            f_bgm.loop = true;

            f_effectSound = this.gameObject.AddComponent<AudioSource>();
        }

        /// <summary> 播放背景音乐 </summary>
        public void PlayBgm(string audioName)
        {
            string oldName = "";
            if (f_bgm.clip == null)
                oldName = "";
            else
                oldName = f_bgm.clip.name;

            if (string.IsNullOrEmpty(oldName))
            {
                AudioClip clip = GetClip(audioName);
                if (clip != null)
                {
                    f_bgm.clip = clip;
                    f_bgm.Play();
                }
            }
        }

        /// <summary> 关闭背景音乐 </summary>
        public void StopBgm()
        {
            f_bgm.Stop();
            f_bgm.clip = null;
        }

        /// <summary> 播放音效 </summary>
        public void PlayEffect(string audioName)
        {
            AudioClip clip = GetClip(audioName);
            f_effectSound.PlayOneShot(clip);
        }

        private AudioClip GetClip(string audioName)
        {
            string path = string.Empty;
            if (string.IsNullOrEmpty(ResourceDir))
                path = string.Empty;
            else
                path = ResourceDir + "/" + audioName;

            return Resources.Load<AudioClip>(path);
        }
             
    }
}

