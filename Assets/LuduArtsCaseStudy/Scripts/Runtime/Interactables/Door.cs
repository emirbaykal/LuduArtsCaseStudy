using LuduArtsCaseStudy.Scripts.Runtime.Core;
using UnityEngine;

namespace LuduArtsCaseStudy.Scripts.Runtime.Interactables
{
    public class Door : InteractableItem
    {
        private bool isOpen = false;

        public override void InteractionStart()
        {
            isOpen = !isOpen;
        }
    }
}