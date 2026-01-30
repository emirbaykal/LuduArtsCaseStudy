using System;
using LuduArtsCaseStudy.Scripts.Runtime.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LuduArtsCaseStudy.Scripts.Runtime.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        private CharacterController characterController;
        
        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
            
            //Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
        }

        private void Update()
        {
            ApplyMovement();
            
            CheckInteract();
        }

        #region Move
        
        [Header("Movement")]
        [SerializeField] private float moveSpeed = 5f;
        private Vector3 direction;

        
        private void ApplyMovement()
        {
            characterController.Move(direction * moveSpeed * Time.deltaTime);
        }

        public void Move(InputAction.CallbackContext context)
        {
            Vector2 moveDelta = context.ReadValue<Vector2>();
            Vector3 camForward = cameraRoot.transform.forward;
            Vector3 camRight = cameraRoot.transform.right;

            camForward.y = 0f;
            camRight.y = 0f;

            camForward.Normalize();
            camRight.Normalize();

            direction = camForward * moveDelta.y + camRight * moveDelta.x;

            transform.position += direction * moveSpeed * Time.deltaTime;
        }

        #endregion


        #region Camera Rotation

        [SerializeField] private Transform cameraRoot;
        [SerializeField] private float sensitivity = 100f;

        float xRotation = 0f;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void OnLook(InputAction.CallbackContext context)
        {
            Vector2 lookDelta = context.ReadValue<Vector2>();

            float mouseX = lookDelta.x * sensitivity * Time.deltaTime;
            float mouseY = lookDelta.y * sensitivity * Time.deltaTime;

            // -------- PITCH (YUKARI-AŞAĞI) --------
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            cameraRoot.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            // -------- YAW (SAĞA-SOLA) --------
            transform.Rotate(Vector3.up * mouseX, Space.World);       
            
        }

        #endregion
        

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