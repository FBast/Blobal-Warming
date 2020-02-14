using System;
using Production.Plugins.XboxCtrlrInput.Assets.Plugins;
using UnityEngine;
using UnityEngine.UI;

namespace Production.Scripts.Components
{
    public class ButtonComponent : MonoBehaviour
    {
        public XboxButton Button;
        public XboxController Controller;
        private void Update()
        {
            OnXboxControllerClick(Controller);
        }

        void OnXboxControllerClick(XboxController controller) {
            if (XCI.GetButtonDown(Button, controller))
            {
                Debug.Log("Click A ");
                this.GetComponent<Button>().onClick.Invoke();
            }
        }
    }
}