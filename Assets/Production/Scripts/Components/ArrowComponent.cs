using UnityEngine;
using UnityEngine.Serialization;

namespace Production.Scripts.Components {
    public class ArrowComponent : MonoBehaviour {
    
        public Transform Arrow;
        [FormerlySerializedAs("arrowY")] public float ArrowY;
    
        public void DisplayOnRespawn() {
            Arrow.gameObject.SetActive(true);
        }

        public void InactiveArrow() {
            Arrow.gameObject.SetActive(false);
        }
    
        private void Update() {
            if (transform.position.y > 8.5f) {
                Arrow.gameObject.SetActive(true);
            }
            Vector2 newPos = transform.position;
            newPos.y = ArrowY;
            Arrow.position = newPos;
        }
        
    }
}
