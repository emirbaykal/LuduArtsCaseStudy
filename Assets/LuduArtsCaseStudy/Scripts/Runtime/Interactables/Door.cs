using LuduArtsCaseStudy.Scripts.Runtime.Core;
using LuduArtsCaseStudy.Scripts.Runtime.Player;
using UnityEngine;

namespace LuduArtsCaseStudy.Scripts.Runtime.Interactables
{
    public class Door : InteractableItem
    {
        private bool m_isOpen = false;

        #region Interaction Override 

        public override void Interact()
        {
            PlayerController instance = PlayerController.Instance;
            if (instance.HaveKey() && !m_isOpen)
            {
                instance.DecraseKey();
                m_isOpen = !m_isOpen;
                Debug.Log("Door is open: " + m_isOpen);
            }
            else
                Debug.LogWarning("YOU NEED KEY. DOOR IS LOCKED!");
            
        }

        #endregion
        
    }
}