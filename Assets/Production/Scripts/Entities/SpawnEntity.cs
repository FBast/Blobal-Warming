using Production.Plugins.RyanScriptableObjects.SOEvents.VoidEvents;
using Production.Plugins.RyanScriptableObjects.SOReferences.BoolReference;
using Production.Scripts.Components;
using Production.Scripts.Utils;
using UnityEngine;
using UnityEngine.Serialization;

namespace Production.Scripts.Entities {
    public class SpawnEntity : MonoBehaviour {
        public Transform SpawnPoint;
        [FormerlySerializedAs("player")] public GameObject PlayerGameObject;
        public BoolReference OnPlayerActive;
        public BoolReference SpawnActive;
        public VoidEvent PlayerSpawn;

        private void Awake() {
            PlayerGameObject.GetComponent<PlayerEntity>().Name.Value = NameGenerator.GenerateName();
        }
        
        public void FirstSpawn() {
            if (SpawnActive.Value) {
                PlayerGameObject.SetActive(true);
                PlayerSpawn.Raise();
                OnPlayerActive.Value = true;
                PlayerGameObject.GetComponent<ArrowComponent>().DisplayOnRespawn();
                PlayerGameObject.transform.position = SpawnPoint.position;
            }
            else {
                Debug.Log("Spawn inactive");
            }
        }

        public void Respawn() {
            if (SpawnActive.Value) {
                PlayerGameObject.GetComponent<ArrowComponent>().DisplayOnRespawn();
                PlayerGameObject.transform.position = SpawnPoint.position;
            }
            else {
                Debug.Log("Respawn inactive");
                PlayerGameObject.SetActive(false);
            }
        }

    }
}
