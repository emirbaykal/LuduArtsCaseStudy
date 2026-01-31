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
        private PlayerController m_playerController;
        [SerializeField] InputActionAsset inputAction;
        private InputAction m_interactAction;

        #region Unity Methods

        private void Awake()
        {
            m_playerController = GetComponent<PlayerController>();
            m_interactAction = inputAction.FindAction("Interact");
        }

        private void OnEnable()
        {
            m_interactAction.Enable();
            m_interactAction.started += OnStarted;
            m_interactAction.performed += OnPerformed;
            m_interactAction.canceled += OnCanceled;
        }
        
        private void OnDisable()
        {
            m_interactAction.started -= OnStarted;
            m_interactAction.performed -= OnPerformed;
            m_interactAction.canceled -= OnCanceled;
            m_interactAction.Disable();
        }

        #endregion


        #region Input Actions

        private void OnStarted(InputAction.CallbackContext context)
        {
            var controller = m_playerController;
            if(controller.CurrentInteractable == null) return;

            InteractionType type = controller.CurrentInteractable.GetInteractionType();

            if (type != InteractionType.Hold)
                controller.CurrentInteractable.Interact();
        }

        private void OnPerformed(InputAction.CallbackContext context)
        {
            var controller = m_playerController;

            if(controller.CurrentInteractable == null) return;

            InteractionType type = controller.CurrentInteractable.GetInteractionType();

            if (type == InteractionType.Hold)
            {
                controller.CurrentInteractable.InteractionStart();
            }
            
        }
        private void OnCanceled(InputAction.CallbackContext context)
        {
            var controller = m_playerController;

            controller.CurrentInteractable.InteractionStop();
        }

        #endregion
        
    }
}