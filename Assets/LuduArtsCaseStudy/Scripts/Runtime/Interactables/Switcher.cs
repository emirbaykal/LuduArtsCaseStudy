using System;
using UnityEngine;

namespace LuduArtsCaseStudy.Scripts.Runtime.Interactables
{
    public class Switcher : InteractableItem
    {
        [Header("Elements")]
        [SerializeField] Material m_openMaterial;
        [SerializeField] Material m_closeMaterial;
        [SerializeField] private MeshRenderer m_renderer;

        private bool m_isOpen = true;


        #region Interaction Override

        public override void Interact()
        {
            m_isOpen = !m_isOpen;
            
            if (m_isOpen)
                m_renderer.material = m_openMaterial;
            else
                m_renderer.material = m_closeMaterial;
        }

        #endregion
        

    }
}