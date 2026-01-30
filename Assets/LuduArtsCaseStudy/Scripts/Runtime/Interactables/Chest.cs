using System;
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
            isHolding = false;
        }

        public override void Interact()
        {
            Debug.Log("Hold finish!");
        }
        private void Update()
        {
            if (isHolding)
                holdTime += Time.deltaTime;
            if (holdTime >= GetHoldTime())
            {
                isHolding = false;
                holdTime = 0;
                
                Interact();
            }
        }
    }
}