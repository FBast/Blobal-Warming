using System.Collections.Generic;
using System.Linq;
using Production.Plugins.RyanScriptableObjects.SOEvents.IntEvents;
using Production.Plugins.RyanScriptableObjects.SOEvents.StringEvents;
using Production.Plugins.RyanScriptableObjects.SOEvents.VoidEvents;
using Production.Plugins.RyanScriptableObjects.SOReferences.BoolReference;
using Production.Plugins.RyanScriptableObjects.SOReferences.FloatReference;
using Production.Plugins.RyanScriptableObjects.SOReferences.GameObjectReference;
using Production.Plugins.RyanScriptableObjects.SOReferences.StringReference;
using Production.Scripts.Components;
using Production.Scripts.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Production.Scripts.Entities {
    public class GameEntity : MonoBehaviour {
    
        [Header("Player Management")] 
        public List<GameObjectReference> PlayersReference = new List<GameObjectReference>();
        public List<PlayerEntity> PlayersEntities = new List<PlayerEntity>();
        public List<BoolReference> ActivePlayers = new List<BoolReference>();
        public BoolReference SpawnActive;
        
        // Initialisation des Instances de Scriptables Objects pour les joueurs au lancement du jeu.
        [Header("Values Initialisation")] 
        [FormerlySerializedAs("MovementSpeed")] public List<FloatReference> MovementSpeeds = new List<FloatReference>();
        [FormerlySerializedAs("Names")] public List<StringReference> PlayerNames = new List<StringReference>();
        public FloatReference MovementSpeedBaseValue;
        public FloatReference ControllerDirection;
        public BoolReference IsLevelScrolling;
        public FloatReference LevelScrollingSpeed;
        public float LevelScrollingSpeedOnStart = 0.02f;

        [Header("Score Management")] 
        public IntEvent DisplayScore;
        public VoidEvent HideOverlay;
        public List<FloatReference> ScoreReference = new List<FloatReference>();
        public ScoreData _scoreData;
    
        [Header("Time Management")]
        public FloatReference CurrentTime;
        public FloatReference Endtime;
        public BoolReference HasGameStarted;
        public float StartingTime = 181f;

        [Header("Scene Management Events")] 
        public StringEvent OnLoadScene;
        public StringEvent OnUnloadScene;
        public string MenuScene;
        public string GameScene;
        
        private void Awake() {
            InitializeEntitiesList();
            InitializeValues();
            ResetScores();
            CurrentTime.Value = StartingTime;
            Endtime.Value = StartingTime;
            HasGameStarted.Value = false;
        }
        
        private void Update() {
            Timer();
        }
        
        private void InitializeScoreList() {
            foreach (PlayerEntity playerEntity in PlayersEntities) {
                //ACTIVE PLAYERS ONLY
                ScoreDataEntry newEntry = new ScoreDataEntry(playerEntity.Name.Value, 
                    playerEntity.playerScore.Value, 
                    playerEntity.GetComponent<BonusHandlerComponent>().PlayerID);
                _scoreData.ScoreList.Add(newEntry);
            }
            _scoreData.PlayerNumberInLastGame = PlayersEntities.Count;
            _scoreData.Display();
        }
        
        public void InitializeEntitiesList() {
            PlayerEntity[] players = FindObjectsOfType<PlayerEntity>();
            PlayersEntities.Clear();
            PlayersEntities = players.ToList();
        }
        
        private void InitializeValues() {
            CurrentTime.Value = StartingTime;
            Endtime.Value = StartingTime;
            SpawnActive.Value = true;
            HasGameStarted.Value = false;
            LevelScrollingSpeed.Value = LevelScrollingSpeedOnStart;
            IsLevelScrolling.Value = false;
            foreach (FloatReference movementSpeed in MovementSpeeds) {
                movementSpeed.Value = MovementSpeedBaseValue.Value;
            }
            ControllerDirection.Value = 1;
            foreach (StringReference playerName in PlayerNames) {
                playerName.Value = "";
            }
            foreach (var player in ActivePlayers) {
                player.Value = false;
            }
        }
        
        private void Timer() {
            if (HasGameStarted.Value) {
                CurrentTime.Value -= Time.deltaTime;
                if (CurrentTime.Value <= 0) {
                    HasGameStarted.Value = false;
                    Debug.Log("End Game");
                    InitializeScoreList();
                    CurrentTime.Value = StartingTime;
                    DisplayScore.Raise(PlayersEntities.Count);
                    HideOverlay.Raise();
                } 
            }
        }
        
        private void ResetScores() {
            foreach (var score in ScoreReference) {
                score.Value = 0;
            }
        }
        
    }
}
