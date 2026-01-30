using LuduArtsCaseStudy.ScriptableObjects.InteractionSystem;
using LuduArtsCaseStudy.Scripts.Runtime.Core;
using UnityEngine;

namespace LuduArtsCaseStudy.Scripts.Runtime.Interactables
{
    public class InteractableItem : MonoBehaviour, IInteractable
    {
        [SerializeField] private InteractionData interactionData;
        
        public InteractionType GetInteractionType() => interactionData.interactionType;
        
        public virtual string GetInteractionText() => interactionData.interactionText;
        public Transform GetTransform() => transform;

        public virtual float GetHoldTime() => interactionData.holdDuration;

        public virtual void InteractionStart() { }
        public virtual void InteractionStop() { }
        public virtual void Interact() { }
        
    }
}