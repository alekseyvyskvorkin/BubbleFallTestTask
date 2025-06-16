using UnityEngine;

namespace Game.Audio
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        [SerializeField] private AudioSource _hitSource;
        [SerializeField] private AudioClip _buttonSound;
        [SerializeField] private AudioClip _bubbleExplodeSound;

        private void Awake()
        {
            Instance = this;
        }

        public void PlayBubbleExplode()
        {
            _hitSource.PlayOneShot(_bubbleExplodeSound);
        }

        public void PlayButtonSound()
        {
            _hitSource.PlayOneShot(_buttonSound);
        }
    }
}
