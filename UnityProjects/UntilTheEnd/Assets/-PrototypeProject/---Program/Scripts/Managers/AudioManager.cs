using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UntilTheEnd
{
    public class AudioManager : DontDestroySingleton<AudioManager>
    {
        public AudioSource audioSourceBGM = null;
        public AudioSource audioSourceEffect = null;

        public List<AudioClip> bgmClipList = new List<AudioClip>();
        public List<AudioClip> effectClipList = new List<AudioClip>();

        public enum BGMAudioType
        {
            LoginBGM = 0,
            InGameBGM = 1
        }

        public enum EffectAudioType
        {
            ClickSound
        }

        public void PlayBGM(BGMAudioType type)
        {
            if (audioSourceBGM == null)
            {
                return;
            }
            else
            {
                audioSourceBGM.clip = bgmClipList[(int)type];
                audioSourceBGM.Play();
            }
        }

        public void PlayOneShot(EffectAudioType type)
        {
            if (audioSourceEffect == null)
            {
                return;
            }
            else
            {
                audioSourceEffect.PlayOneShot(effectClipList[(int)type]);
            }
        }

        public void OnClickButtonSound()
        {
            PlayOneShot(EffectAudioType.ClickSound);
        }
    }
}