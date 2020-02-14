using UnityEngine;

namespace Production.Scripts.Platforms
{
    public class ExplosivePlaform : MonoBehaviour
    {
        public GameObject ExplosionParticules;
        public GameObject ExplosionRangeCollision;
        public SoundComponent sc;

        
        public float timerAfterHit;
        public float timerExplosionTime;
        private bool IsActive;
        private bool IsExploding;

        private void Start()
        {
            ExplosionRangeCollision.SetActive(false);
            sc = GetComponent<SoundComponent>();
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
                sc.Play("ExplosionSound");
                
            }

            if (IsExploding) timerExplosionTime -= Time.deltaTime;

            if (timerExplosionTime <= 0)
            {
                Destroy(gameObject);
            }
        }

    }
}
