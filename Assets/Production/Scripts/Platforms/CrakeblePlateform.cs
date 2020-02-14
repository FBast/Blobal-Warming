using System;
using UnityEngine;

namespace Production.Scripts.Platforms
{
    public class CrakeblePlateform : MonoBehaviour
    {
        public float TimerBeforeCrack = 3f;
        public float TimerBeforeDestruct = 1f;
        public GameObject RockFallingParticle;
        private SoundComponent crackingSound;

        private bool _hasBeenSteppedOn;
        private bool _isDead;

        private void Start()
        {
            _hasBeenSteppedOn = false;
            crackingSound = GetComponent<SoundComponent>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!_hasBeenSteppedOn)
            {
                PlaySteppedFeedback();
            }
            _hasBeenSteppedOn = true;
        }
        
        private void PlaySteppedFeedback()
        {
            crackingSound.Play("Stepped");
        }

        private void PlayDestroyFeedback()
        {
            crackingSound.Play("DestroySound");
            _isDead = true;
        }

        private void Update()
        {
            if (_hasBeenSteppedOn)
            {
                TimerBeforeCrack -= Time.deltaTime;
            }
            if (TimerBeforeCrack <= 0)
            {
                TimerBeforeDestruct -= Time.deltaTime;
                if (!_isDead)
                {
                    PlayDestroyFeedback();
                }
            }
            if (TimerBeforeDestruct <= 0)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
