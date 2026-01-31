using LuduArtsCaseStudy.Scripts.Runtime.Player;
using UnityEngine;

namespace LuduArtsCaseStudy.Scripts.Runtime.Interactables
{
    public class Key : InteractableItem
    {
        #region Interaction Override

        public override void Interact()
        {
            PlayerController.Instance.TakeKey();
        }

        public override void InteractionStop()
        {
            Transform topParent = transform;
            while (topParent.parent != null)
                topParent = topParent.parent;

            topParent.transform.position = new Vector3(-500, -500, -500);
            
        }

        #endregion
        
    }
}