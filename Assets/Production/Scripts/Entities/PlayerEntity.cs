using System.Collections.Generic;
using Production.Plugins.RyanScriptableObjects.SOReferences.FloatReference;
using Production.Plugins.RyanScriptableObjects.SOReferences.GameObjectReference;
using Production.Plugins.RyanScriptableObjects.SOReferences.StringReference;
using Production.Scripts.Components;
using UnityEngine;
using UnityEngine.Serialization;

namespace Production.Scripts.Entities {
    public class PlayerEntity : MonoBehaviour, IMovement, IHealth, IScore {
        
        [Header("SO References")] 
        [FormerlySerializedAs("CurrentPlayerReferences")] public GameObjectReference CurrentPlayerReference;
        public List<GameObjectReference> OtherPlayers = new List<GameObjectReference>();

        public StringReference Name;
        private void Awake() {
            CurrentPlayerReference.Value = gameObject;
            _playerController = GetComponent<PlayerController>();
        }
        
        [SerializeField] private float _maxHP;
        public float MaxHP {
            get => _maxHP;
            set => _maxHP = value;
        }
        
        [SerializeField] private InputEntity _inputEntity;
        public InputEntity inputEntity {
            get=> _inputEntity;
            set => _inputEntity = value;
        }
        
        private PlayerController _playerController;
        public PlayerController playerController {
            get => _playerController;
            set => _playerController = value;
        }
        
        [SerializeField] private Transform _playerTransform;
        public Transform playerTransform {
            get => _playerTransform;
            set => _playerTransform = value;
        }

        [SerializeField] private FloatVariable _playerScore;
        public FloatVariable playerScore {
            get=> _playerScore;
            set => _playerScore = value;
        }
        
    }
}
