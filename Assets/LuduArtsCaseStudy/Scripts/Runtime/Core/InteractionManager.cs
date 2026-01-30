using UnityEngine;

namespace LuduArtsCaseStudy.Scripts.Runtime.Core
{
    public enum InteractionType
    {
        Instant,
        Hold,
        Toggle
    }
    
    public interface IInteractable
    {
        InteractionType GetInteractionType();
        string GetInteractionText(); 
        Transform GetTransform();
        float GetHoldTime(); // for hold
        void InteractionStart(); //toggle on hold start 
        void InteractionStop(); //toggle of/ hold cancel 
        void Interact();
    }
}
