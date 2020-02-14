using UnityEngine;

namespace Production.Scripts.Platforms
{
    public class ExplosivePlaform : MonoBehaviour
    {
        public GameObject ExplosionParticules;
        public GameObject ExplosionRangeCollision;
        private SoundComponent sc;

        
        public float timerAfterHit;
        public float timerExplosionTime;
        private bool HasBeenSteppedOn;
        private bool IsExploding;
        private bool HasExploded;


        private void Start()
        {
            ExplosionRangeCollision.SetActive(false);
            sc = GetComponent<SoundComponent>();
            HasExploded = false;
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!HasBeenSteppedOn)
            {
                PlayCountdownFeedback();
            }
            HasBeenSteppedOn = true;
            //ExplosionAnimator.SetTrigger("Explode");
        }

        private void PlayCountdownFeedback()
        {
            sc.Play("CountdownSound");
        }

        private void PlayExplosionFeedback()
        {
            Instantiate(ExplosionParticules, transform);
            sc.Play("ExplosionSound");
            HasExploded = true;
        }

        void Update()
        {
            if (HasBeenSteppedOn) timerAfterHit -= Time.deltaTime;
            if (timerAfterHit <= 0)
            {
                IsExploding = true;
                ExplosionRangeCollision.SetActive(true);
                if (!HasExploded)
                {
                    PlayExplosionFeedback();
                }
            }

            if (IsExploding) timerExplosionTime -= Time.deltaTime;

            if (timerExplosionTime <= 0)
            {
                Destroy(gameObject);
            }
        }

    }
}
