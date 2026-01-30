using System;
using LuduArtsCaseStudy.Scripts.Runtime.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LuduArtsCaseStudy.Scripts.Runtime.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        private Vector2 input;
        private CharacterController characterController;
        private Vector3 direction;
        
        
        [SerializeField] private float speed;
        
        

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
            
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            ApplyMovement();
            
            CheckInteract();
        }
        

        private void ApplyMovement()
        {
            characterController.Move(direction * speed * Time.deltaTime);
        }

        public void Move(InputAction.CallbackContext context)
        {
            input = context.ReadValue<Vector2>();
            direction = new Vector3(input.x, 0, input.y);
        }
        
        [SerializeField] private Transform cameraRoot;
        [SerializeField] private float sensitivity = 0.1f;

        private float xRotation = 0f;

        public void OnLook(InputAction.CallbackContext context)
        {
            Vector2 lookDelta = context.ReadValue<Vector2>() * sensitivity;

            //// Yukarı-aşağı (kamera)
            //xRotation -= lookDelta.y;
            //xRotation = Mathf.Clamp(xRotation, -80f, 80f);
            //cameraRoot.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            // Sağa-sola (body)
            transform.Rotate(Vector3.up * lookDelta.x);
        }

        #region InteractionSystem

        public float interactDistance = 3f;
        public LayerMask interactMask;
        
        private IInteractable currentInteractable;
        public IInteractable CurrentInteractable => currentInteractable; 

        private float holdTimer;
        private bool isHolding;
        
        private void CheckInteract()
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            
            Debug.DrawRay(ray.origin, ray.direction * interactDistance, Color.red);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactDistance, interactMask))
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();

                if (interactable != null)
                {
                    currentInteractable = interactable;
                    Debug.DrawLine(ray.origin, hit.point, Color.green);

                    Debug.Log(currentInteractable);
                    
                    //UIManager.instance.ShowInteractionText(interactable.GetInteractionText());
                    return;
                }
            }
            
            currentInteractable = null;
            //UIManager.Instance.HideInteractionText();
        }
        
        #endregion
    }
}