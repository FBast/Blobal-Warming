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
                Instantiate(RockFallingParticle, transform);
                crackingSound.PlayOneShot(crackingSound.clip);
                TimerBeforeDestruct -= Time.deltaTime;
            }

            if (TimerBeforeDestruct <= 0)
            {
                Destroy(gameObject);
            }
        }


        /*private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Touche");
        childCube.GetComponent<MeshRenderer>().material.color = Color.red;
        PlateformHp--;
        if (PlateformHp == 0)
        {
            Destroy(this.gameObject);
        }
    }*/

        /*private void OnCollisionEnter2D(Collision2D other)
        {
            if (!IsBeingSteppedOn)
            {
                PlateformHp--;
                Debug.Log("Touché ! HP = " + PlateformHp);



                if (PlateformHp == 1)
                {
                    //childCube.GetComponent<MeshRenderer>().material.color = Color.red;
                    //Change material parameter for fissure
                }
                if (PlateformHp == 0)
                {
                    if (destroySound != null)
                    {
                        AudioSource.PlayClipAtPoint(destroySound, transform.position);
                    }
                    Destroy(this.gameObject);
                }
            }
            IsBeingSteppedOn = true;
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            IsBeingSteppedOn = false;
        }*/
    }
    
    
    
}
