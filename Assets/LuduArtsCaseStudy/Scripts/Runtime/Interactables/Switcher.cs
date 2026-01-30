using System;
using UnityEngine;

namespace LuduArtsCaseStudy.Scripts.Runtime.Interactables
{
    public class Switcher : InteractableItem
    {
        [Header("Elements")]
        [SerializeField] Material openMaterial;
        [SerializeField] Material closeMaterial;
        [SerializeField] private MeshRenderer renderer;

        private bool isOpen = true;


        public override void Interact()
        {
            isOpen = !isOpen;
            
            if (isOpen)
                renderer.material = openMaterial;
            else
                renderer.material = closeMaterial;
        }

    }
}