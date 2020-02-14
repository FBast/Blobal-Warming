using System;
using UnityEngine;

namespace Production.Scripts.Platforms
{
    public class CrakeblePlateform : MonoBehaviour
    {
        public float TimerBeforeCrack = 3f;
        public float TimerBeforeDestruct = 1f;
        public GameObject RockFallingParticle;
        private AudioSource crackingSound;

        private bool _hasBeenSteppedOn;

        private bool _isDead;
        //public int PlateformHp = 4;
        //public GameObject childCube;
        //private bool IsBeingSteppedOn;

        private void Start()
        {
            _hasBeenSteppedOn = false;
            crackingSound = GetComponent<AudioSource>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            _hasBeenSteppedOn = true;
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
            }
            if (TimerBeforeDestruct <= 0)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
