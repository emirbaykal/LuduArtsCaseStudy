using LuduArtsCaseStudy.Scripts.Runtime.Core;
using LuduArtsCaseStudy.Scripts.Runtime.Player;
using UnityEngine;

namespace LuduArtsCaseStudy.Scripts.Runtime.Interactables
{
    public class Door : InteractableItem
    {
        private bool isOpen = false;

        public override void Interact()
        {
            PlayerController instance = PlayerController.Instance;
            if (instance.HaveKey())
            {
                instance.DecraseKey();
                isOpen = !isOpen;
                Debug.Log("Door is open: " + isOpen);
            }
            else
                Debug.LogWarning("YOU NEED KEY. DOOR IS LOCKED!");
            
        }
    }
}