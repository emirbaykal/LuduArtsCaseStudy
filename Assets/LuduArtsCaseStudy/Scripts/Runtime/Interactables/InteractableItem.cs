using LuduArtsCaseStudy.ScriptableObjects.InteractionSystem;
using LuduArtsCaseStudy.Scripts.Runtime.Core;
using UnityEngine;

namespace LuduArtsCaseStudy.Scripts.Runtime.Interactables
{
    public class InteractableItem : MonoBehaviour, IInteractable
    {
        [SerializeField] private InteractionData m_interactionData;
        
        public InteractionType GetInteractionType() => m_interactionData.interactionType;
        
        public virtual string GetInteractionText() => m_interactionData.interactionText;
        public Transform GetTransform() => transform;

        public virtual float GetHoldTime() => m_interactionData.holdDuration;

        public virtual void InteractionStart() { }
        public virtual void InteractionStop() { }
        public virtual void Interact() { }
        
    }
}