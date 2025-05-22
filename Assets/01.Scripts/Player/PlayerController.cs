using UnityEngine;
using UnityEngine.InputSystem;

namespace _01.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("이동관련")] 
        public float moveSpeed;
        public LayerMask groundLayerMask;
        public float jumpForce;

        [Header("카메라")] 
        public Transform cameraContainer;

        public float minXLook;
        public float maxXLook;
        public float lookSensitivity;
        private float camCurXRot;
        private Vector2 mouseDelta;
    
    
    
        private Rigidbody _rigidbody;
        private Vector2 curMovementInput;
    
        public 
    
    
    
    
            void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

   
        void FixedUpdate()
        {
            Move();
        }

        void LateUpdate()
        {
            CameraLook();
        }

        void CameraLook()
        {
            camCurXRot += mouseDelta.y * lookSensitivity;
            camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
            cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);
        
            transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
        }

        private void Move()
        {
            Vector3 moveDir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
            moveDir *= moveSpeed;
            moveDir.y = _rigidbody.velocity.y;

            _rigidbody.velocity = moveDir;
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                curMovementInput = context.ReadValue<Vector2>();
            }
            else if (context.phase == InputActionPhase.Canceled)
            {
                curMovementInput = Vector2.zero;
            }
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Started && IsGrounded())
            {
                _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
            }
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            mouseDelta = context.ReadValue<Vector2>();
        }
    
    
        bool IsGrounded()
        {
            Ray[] rays = new Ray[4]
            {
                new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
                new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
                new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down ),
                new Ray(transform.position + (-transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down)
            };

            for (int i = 0; i < rays.Length; i++)
            {
                if (Physics.Raycast(rays[i], 0.6f, groundLayerMask))
                {
                    return true;
                }
            }
            return false;
        }
   
    }
}
