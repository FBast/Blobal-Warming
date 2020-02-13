using System;
using Production.Plugins.RyanScriptableObjects.SOReferences.BoolReference;
using Production.Plugins.RyanScriptableObjects.SOReferences.FloatReference;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class TrunkSlider : MonoBehaviour {

    public FloatReference LevelScrollingSpeed;
    public BoolReference IsScrolling;
    public float SpeedMultiplicator;

    private SpriteRenderer _spriteRenderer;
    private Vector4 _position = Vector4.zero;

    private void Awake() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        if (IsScrolling.Value) {
            _position += new Vector4(0, LevelScrollingSpeed.Value * SpeedMultiplicator, 0, 0);
        }
        _spriteRenderer.material.SetVector("_Offset", _position);
    }
    
}
