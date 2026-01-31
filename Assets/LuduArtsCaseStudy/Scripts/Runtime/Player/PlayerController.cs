using System;
using LuduArtsCaseStudy.Scripts.Runtime.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LuduArtsCaseStudy.Scripts.Runtime.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController Instance;
        
        private CharacterController m_characterController;

        #region Unity Methods

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
                Destroy(gameObject);
            
            m_characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            ApplyMovement();
            
            CheckInteract();
        }

        #endregion
        

        #region Move
        
        [Header("Movement")]
        [SerializeField] private float m_moveSpeed = 5f;
        private Vector3 direction;
        
        private void ApplyMovement()
        {
            m_characterController.Move(direction * m_moveSpeed * Time.deltaTime);
        }

        /// <summary>
        /// Processes character movement input data
        /// </summary>
        /// <param name="context"> Inputs delta values</param>
        public void Move(InputAction.CallbackContext context)
        {
            Vector2 moveDelta = context.ReadValue<Vector2>();
            Vector3 camForward = m_cameraRoot.transform.forward;
            Vector3 camRight = m_cameraRoot.transform.right;

            camForward.y = 0f;
            camRight.y = 0f;

            camForward.Normalize();
            camRight.Normalize();

            direction = camForward * moveDelta.y + camRight * moveDelta.x;

            transform.position += direction * m_moveSpeed * Time.deltaTime;
        }

        #endregion
        
        #region Camera Rotation

        [SerializeField] private Transform m_cameraRoot;
        [SerializeField] private float sensitivity = 100f;

        float xRotation = 0f;

        /// <summary>
        /// Processes FPS camera move inputs
        /// </summary>
        /// <param name="context">Inputs delta values</param>
        public void OnLook(InputAction.CallbackContext context)
        {
            Vector2 lookDelta = context.ReadValue<Vector2>();

            float mouseX = lookDelta.x * sensitivity * Time.deltaTime;
            float mouseY = lookDelta.y * sensitivity * Time.deltaTime;

            // -------- PITCH (YUKARI-AŞAĞI) --------
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            m_cameraRoot.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            // -------- YAW (SAĞA-SOLA) --------
            transform.Rotate(Vector3.up * mouseX, Space.World);       
            
        }

        #endregion
        
        #region InteractionSystem

        [SerializeField] private float m_interactDistance = 3f;
        [SerializeField] public LayerMask m_interactMask;
        
        private IInteractable currentInteractable;
        public IInteractable CurrentInteractable => currentInteractable; 

        private float holdTimer;
        private bool isHolding;
        
        private void CheckInteract()
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            
            Debug.DrawRay(ray.origin, ray.direction * m_interactDistance, Color.red);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, m_interactDistance, m_interactMask))
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();

                if (interactable != null)
                {

                    currentInteractable = interactable;
                    Debug.DrawLine(ray.origin, hit.point, Color.green);
                    
                    UIManager.Instance.ShowItemText(currentInteractable.GetInteractionText(), currentInteractable.GetTransform().position);
                    return;
                }
            }
            
            currentInteractable = null;
            UIManager.Instance.HideItemText();
        }
        
        #endregion

        #region KeyItem
        
        private int m_keyAmount = 0;
        public int KeyAmount => m_keyAmount;

        /// <summary>
        /// increases the character's key
        /// </summary>
        public void TakeKey()
        {
            m_keyAmount++;
        }

        /// <summary>
        /// decrease the character's key
        /// </summary>
        public void DecraseKey()
        {
            m_keyAmount--;
        }

        /// <summary>
        /// checks if the character has a key
        /// </summary>
        /// <returns></returns>
        public bool HaveKey()
        {
            return m_keyAmount > 0;
        }

        #endregion
    }
}