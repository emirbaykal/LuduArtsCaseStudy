using System;
using System.Collections;
using LuduArtsCaseStudy.Scripts.Runtime.Core;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

namespace LuduArtsCaseStudy.Scripts.Runtime.Player
{
    public class PlayerInput : MonoBehaviour
    {
        private PlayerController playerController;
        [SerializeField] InputActionAsset inputAction;
        private InputAction interactAction;
        private Coroutine holdRoutine;
        

        private void Awake()
        {
            playerController = GetComponent<PlayerController>();
            interactAction = inputAction.FindAction("Interact");
        }

        private void OnEnable()
        {
            interactAction.Enable();
            interactAction.started += OnStarted;
            interactAction.performed += OnPerformed;
            interactAction.canceled += OnCanceled;
        }
        
        private void OnDisable()
        {
            interactAction.started -= OnStarted;
            interactAction.performed -= OnPerformed;
            interactAction.canceled -= OnCanceled;
            interactAction.Disable();
        }
        
        private void OnStarted(InputAction.CallbackContext context)
        {
            var controller = playerController;
            if(controller.CurrentInteractable == null) return;

            InteractionType type = controller.CurrentInteractable.GetInteractionType();

            if (type != InteractionType.Hold)
                controller.CurrentInteractable.InteractionStart();
        }

        private void OnPerformed(InputAction.CallbackContext context)
        {
            var controller = playerController;

            if(controller.CurrentInteractable == null) return;

            InteractionType type = controller.CurrentInteractable.GetInteractionType();

            if (type == InteractionType.Hold)
            {
                Debug.Log("Holding");
                controller.CurrentInteractable.Interact();
            }
            
        }
        private void OnCanceled(InputAction.CallbackContext context)
        {
            var controller = playerController;

            Debug.Log("Canceled");
            controller.CurrentInteractable.InteractionStop();

        }
    }
}