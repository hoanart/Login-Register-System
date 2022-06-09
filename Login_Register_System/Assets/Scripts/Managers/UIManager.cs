using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Task.UI
{
    public class UIManager : Signleton<UIManager>
    {
        public Button loginButton;
        public Image loadingImg;
        public Popup popup;
        
        #region Popup
        /// <summary>
        /// Activate the GameObject.
        /// </summary>
        /// <param name="target"></param>
        public void Active(GameObject target)
        {
            target.SetActive(true);
        }
        
        /// <summary>
        /// Deactivate the GameObject.
        /// </summary>
        /// <param name="target"></param>
        public void Deactivate(GameObject target)
        {
            target.SetActive(false);
        }
        #endregion
    }

    [System.Serializable]
    public struct Popup
    {
        public GameObject main;
        public Animation animation;
        public Button loginButton;
        public TMP_InputField ID;
        public TMP_InputField password;
    }
}
