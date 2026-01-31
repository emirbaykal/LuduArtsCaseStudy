using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LuduArtsCaseStudy.Scripts.Runtime.Core
{
    public class UIManager : MonoBehaviour
    {
        #region Instance

        public static UIManager Instance;
        
        #endregion

        #region UI Elements

        [Header("UI Elements")]
        [SerializeField] private TextMeshProUGUI m_itemText;

        [SerializeField] private Slider m_holdSlider;

        #endregion
        

        #region Unity Methods

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
                Destroy(gameObject);
            
            m_itemText.gameObject.SetActive(false);
        }

        #endregion
       

        /// <summary>
        /// When Itema Interact is active,
        /// it displays interaction information on the screen. 
        /// </summary>
        /// <param name="text">Retrieves the interaction text from “Interaction Data”</param>
        /// <param name="worldPosition">Retrieves the position of the interacted object.</param>
        public void ShowItemText(string text, Vector3 worldPosition)
        {
            m_itemText.text = text;
            m_itemText.gameObject.SetActive(true);
            
            Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPosition); 
            m_itemText.transform.position = screenPos;
        }

        /// <summary>
        /// When the interaction ends,
        /// the text on the screen is closed.
        /// </summary>
        public void HideItemText()
        {
            m_itemText.gameObject.SetActive(false);
        }
        
        /// <summary>
        /// The current value in the hold interaction is updated.
        /// </summary>
        /// <param name="value">The duration of the hold</param>
        
        public void ChangeHoldSlider(float value)
        {
            print("aaa");
            m_holdSlider.gameObject.SetActive(true);
            m_holdSlider.value = value;
        }

        /// <summary>
        /// The hold slider on the screen is turned off.
        /// </summary>
        public void HideHoldSlider()
        {
            m_holdSlider.gameObject.SetActive(false);
            m_holdSlider.value = 0;
        }
    }
}