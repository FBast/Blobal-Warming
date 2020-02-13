using System;
using Production.Plugins.RyanScriptableObjects.SOReferences.GameObjectReference;
using UnityEngine;

namespace Production.Scripts.Utils
{
    public class ReferenceInitializer : MonoBehaviour
    {
        public GameObjectReference GameObjectReference;

        private void Awake()
        {
            GameObjectReference.Value = gameObject;
        }
    }
}