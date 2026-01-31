using System;
using LuduArtsCaseStudy.Scripts.Runtime.Core;
using UnityEngine;

namespace LuduArtsCaseStudy.Scripts.Runtime.Interactables
{
    public class Chest : InteractableItem
    {
        private bool isHolding = false;
        private float holdTime = 0;

        #region Interaction Override

        // Interaction start
        public override void InteractionStart()
        {
            isHolding = true;
        }

        // Interaction complete

        public override void InteractionStop()
        {
            StopHold();
        }
        
        public override void Interact()
        {
            Debug.Log("Hold Success! Chest open.");
        }

        #endregion
        
        private void Update()
        {
            if (isHolding)
            {
                holdTime += Time.deltaTime;
                UIManager.Instance.ChangeHoldSlider(holdTime / GetHoldTime());
            }
            if (holdTime >= GetHoldTime())
            {
                StopHold();
                //Hold success
                Interact();
            }
        }

        //Reset Hold
        private void StopHold()
        {
            isHolding = false;
            holdTime = 0;
            UIManager.Instance.HideHoldSlider();
        }
    }
}