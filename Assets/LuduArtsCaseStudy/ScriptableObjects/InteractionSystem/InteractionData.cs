using LuduArtsCaseStudy.Scripts.Runtime.Core;
using UnityEngine;

namespace LuduArtsCaseStudy.ScriptableObjects.InteractionSystem
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Interaction/Interaction Data")]

    public class InteractionData : ScriptableObject
    {
        public string interactionText;
        public InteractionType interactionType;
        public float holdDuration;
    }
}