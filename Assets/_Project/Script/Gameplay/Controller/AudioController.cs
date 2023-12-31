using BelumProduktif.Managers;
using UnityEngine;
using BelumProduktif.Enum;

namespace BelumProduktif.Gameplay.Controller
{
    [AddComponentMenu("Tsukuyomi/Controller/AudioController")]
    public class AudioController : MonoBehaviour
    {
        #region Variable

        [Header("Audio Controller Component")]
        public SoundEnum playSoundEnum;
    
        [Header("Reference")]
        private AudioManager audioManager;
    
        #endregion
    
        #region MonoBehaviour Callbacks

        private void Awake()
        {
            audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        }

        private void Start()
        {
            PlayBGM(playSoundEnum);
        }

        #endregion

        #region Tsukuyomi Callbacks
    
        private void PlayBGM(SoundEnum playEnum) => audioManager.PlayAudio(playSoundEnum);
    
        #endregion
    }
}
