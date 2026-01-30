using System;
using LuduArtsCaseStudy.Scripts.Runtime.Core;
using UnityEngine;

namespace LuduArtsCaseStudy.Scripts.Runtime.Interactables
{
    public class Chest : InteractableItem
    {
        private bool isHolding = false;
        private float holdTime = 0;
        
        public override void InteractionStart()
        {
            isHolding = true;
        }

        public override void InteractionStop()
        {
            StopHold();
        }
        
        public override void Interact()
        {
            Debug.Log("Hold Success!");
            
        }
        private void Update()
        {
            if (isHolding)
            {
                Debug.Log("hold");
                holdTime += Time.deltaTime;
                UIManager.Instance.ChangeHoldSlider(holdTime / GetHoldTime());
            }
            if (holdTime >= GetHoldTime())
            {
                StopHold();
                Interact();
            }
        }

        private void StopHold()
        {
            isHolding = false;
            holdTime = 0;
            UIManager.Instance.HideHoldSlider();
        }
    }
}