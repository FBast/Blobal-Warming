using System;
using Production.Plugins.RyanScriptableObjects.SOReferences.GameObjectReference;
using UnityEngine;

namespace Production.Scripts.UI
{
    public class MenuEventsEntity : MonoBehaviour
    {
        public GameObjectReference CreditsPanel;
        public GameObjectReference ScorePanel;
        public GameObjectReference MenuPanel;

        private void Start()
        {
            OpenMenu();
        }

        public void OpenCredits()
        {
            CreditsPanel.Value.SetActive(true);
            ScorePanel.Value.SetActive(false);
            MenuPanel.Value.SetActive(false);
        }

        public void OpenMenu()
        {
            CreditsPanel.Value.SetActive(false);
            ScorePanel.Value.SetActive(false);
            MenuPanel.Value.SetActive(true);  
        }
    }
}