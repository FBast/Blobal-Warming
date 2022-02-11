using System;
using Production.Plugins.XboxCtrlrInput.Assets.Plugins;
using UnityEngine;

namespace Production.Scripts.Entities
{
    public class InputEntity : MonoBehaviour
    {
      
        public bool Jump;
        public bool ActivateItem;
        public bool Dash;
        public XboxController XboxController;
        public float HorizontalInput;
        public Vector3 RightStickAxisInput;
        public Vector3 LeftStickAxisInput;
        public GameObject Player;
        
        private Array _buttons;
        private Array _sticks;
        private SpawnEntity _spawnEntity;
        private bool _hasDetected;
        
        private void Start() {
            _spawnEntity = GetComponent<SpawnEntity>();
            Player.SetActive(false);
            if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor) {
                Debug.Log("Windows Only:: Controller 1 Plugged in: " + XCI.IsPluggedIn(XboxController.First));
                Debug.Log("Windows Only:: Controller 2 Plugged in: " + XCI.IsPluggedIn(XboxController.Second));
                Debug.Log("Windows Only:: Controller 3 Plugged in: " + XCI.IsPluggedIn(XboxController.Third));
                Debug.Log("Windows Only:: Controller 2 Plugged in: " + XCI.IsPluggedIn(XboxController.Fourth));
            }
            _buttons = Enum.GetValues(typeof(XboxButton));
            _sticks = Enum.GetValues(typeof(XboxAxis));
        }
        private void Update() {
            Inputs();
            ActivateOnDetectJoystick();
        }

        private void Inputs() {
              ActivateItem = XCI.GetButtonDown(XboxButton.B, XboxController);
              HorizontalInput = XCI.GetAxis(XboxAxis.LeftStickX, XboxController);
              LeftStickAxisInput = new Vector3(XCI.GetAxis(XboxAxis.LeftStickX,XboxController), XCI.GetAxis(XboxAxis.LeftStickY,XboxController), 0);
              Jump = XCI.GetButtonDown(XboxButton.A, XboxController);
              Dash = XCI.GetButtonDown(XboxButton.RightBumper, XboxController);
              RightStickAxisInput = new Vector3(XCI.GetAxis(XboxAxis.RightStickX,XboxController), XCI.GetAxis(XboxAxis.RightStickY,XboxController), 0);
             
        }


        private void ActivateOnDetectJoystick() {
            if (_hasDetected == false) {
                // Array values = Enum.GetValues(typeof(XboxButton));
                foreach( XboxButton val in _buttons ) {
                    if (XCI.GetButton(val, XboxController) == true) {
                        _hasDetected = true;
                        _spawnEntity.FirstSpawn();
                    }
                }
                foreach (XboxAxis ax in _sticks) {
                    if (XCI.GetAxis(ax, XboxController) > 0 || XCI.GetAxis(ax, XboxController) < 0) {
                        _hasDetected = true;
                        _spawnEntity.FirstSpawn();
                    }
                }
            }
        }

    }
}