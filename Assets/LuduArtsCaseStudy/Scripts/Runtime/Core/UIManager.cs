using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LuduArtsCaseStudy.Scripts.Runtime.Core
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;

        [Header("UI Elements")]
        [SerializeField] private TextMeshProUGUI itemText;

        [SerializeField] private Slider holdSlider;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
                Destroy(gameObject);
            
            itemText.gameObject.SetActive(false);
        }

        public void ShowItemText(string text, Vector3 worldPosition)
        {
            itemText.text = text;
            itemText.gameObject.SetActive(true);
            
            Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPosition); 
            itemText.transform.position = screenPos;
        }

        public void HideItemText()
        {
            itemText.gameObject.SetActive(false);
        }
        
        public void ChangeHoldSlider(float value)
        {
            print("aaa");
            holdSlider.gameObject.SetActive(true);
            holdSlider.value = value;
        }

        public void HideHoldSlider()
        {
            holdSlider.gameObject.SetActive(false);
            holdSlider.value = 0;
        }
    }
}