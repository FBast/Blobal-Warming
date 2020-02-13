using UnityEngine;

namespace Production.Scripts.Platforms
{
    public class ExplosivePlaform : MonoBehaviour
    {
        public GameObject ExplosionParticules;
        public GameObject ExplosionRangeCollision;
        public AudioClip ExplosionSound;

        
        public float timerAfterHit;
        public float timerExplosionTime;
        private bool IsActive;
        private bool IsExploding;

        private void Start()
        {
            ExplosionRangeCollision.SetActive(false);
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            IsActive = true;
            //ExplosionAnimator.SetTrigger("Explode");
        }

        void Update()
        {
            if (IsActive) timerAfterHit -= Time.deltaTime;
            if (timerAfterHit <= 0)
            {
                IsExploding = true;
                ExplosionRangeCollision.SetActive(true);
                Instantiate(ExplosionParticules, transform);
                //ExplosionSound Play Audio
            }

            if (IsExploding) timerExplosionTime -= Time.deltaTime;

            if (timerExplosionTime <= 0)
            {
                Destroy(gameObject);
            }
        }

    }
}
