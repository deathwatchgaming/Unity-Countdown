// Using - Engine
using UnityEngine;

// Namespace - UBRS.TestStuff_FPSController
namespace UBRS.TestStuff_FPSController
{

    // Require - Component - CharacterController
    [RequireComponent(typeof(CharacterController))]

    // Public - Class - TestStuff_FPSController
    public class TestStuff_FPSController : MonoBehaviour
    {
        // Wall Jump - Walljumping

        // Remember that Wall Elements should be tagged accordingly ;)
        // Remember that colliders can be your friend :P

        // Public - LayerMask
        public LayerMask wallLayer;
        // Public- float
        public float wallJumpForce = 10f;
        // Private - bool
        private bool isTouchingWall = false;

        // Crouch - Crouching

        // Public - bool 
        public bool isCrouching = false;
        // Public - float 
        public float crouchHeight = 0.5f;
        // Public - float 
        public float crouchSpeed = 3.5f;
        // Public - float 
        public float crouchTransitionSpeed = 10f;
        // Private - float
        private float originalHeight;
        // Public - float
        public float crouchCameraOffset = -0.5f;
        // Private - Vector3
        private Vector3 cameraStandPosition;
        // Private - Vector3
        private Vector3 cameraCrouchPosition;

        // Mobility - Normal

        // Public - float 
        public float walkingSpeed = 7.5f;
        // Public - float 
        public float runningSpeed = 11.5f;
        // Public - float
        public float jumpSpeed = 8.0f;
        // Public - float
        public float gravity = 20.0f;
        // Public - Camera
        public Camera playerCamera;
        // Public - float
        public float lookSpeed = 2.0f;
        // Public - float
        public float lookXLimit = 45.0f;

        // CharacterController
        CharacterController characterController;

        // Vector3 - moveDirection
        Vector3 moveDirection = Vector3.zero;

        // Float - rotationX
        float rotationX = 0;

        // Hide
        [HideInInspector]
        public bool canMove = true;

        // Start
        void Start()
        {

            // characterController - Get Component - CharacterController
            characterController = GetComponent<CharacterController>();

            // store the original height of the 'CharacterController' and set camera positions
            originalHeight = characterController.height;

            // Define camera positions for standing and crouching
            cameraStandPosition = playerCamera.transform.localPosition;
            cameraCrouchPosition = cameraStandPosition + new Vector3(0, crouchCameraOffset, 0);

            // Lock cursor
            Cursor.lockState = CursorLockMode.Locked;

            // Cursor - Visible
            Cursor.visible = false;

        } // Close - Start

        // Update
        void Update()
        {

            // We are grounded, so recalculate move direction based on axes

            // Vector3 - Forward
            Vector3 forward = transform.TransformDirection(Vector3.forward);

            // Vector3 - Right
            Vector3 right = transform.TransformDirection(Vector3.right);

            // Press Left Shift to run
            bool isRunning = Input.GetKey(KeyCode.LeftShift);

            // Adjust the player's movement speed based on the current state

            // Float - curSpeedX
            float curSpeedX = canMove ? (isRunning ? runningSpeed : (isCrouching ? crouchSpeed : walkingSpeed)) * Input.GetAxis("Vertical") : 0;

            // Float - curSpeedY
            float curSpeedY = canMove ? (isRunning ? runningSpeed : (isCrouching ? crouchSpeed : walkingSpeed)) * Input.GetAxis("Horizontal") : 0;

            // Float - movementDirectionY
            float movementDirectionY = moveDirection.y;

            // moveDirection
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);

            // Ground Jump logic

            // If
            if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
            {

                // moveDirection - y - jumpspeed
                moveDirection.y = jumpSpeed;

            }

            // Wall Jump - Implement the Wall Jumping

            // Else If
            else if (Input.GetButton("Jump") && canMove && isTouchingWall)
            {

                // moveDirection - y - walljumforce
                moveDirection.y = wallJumpForce;

                // This adds a bit of horizontal force opposite the wall for a more dynamic jump

                // If
                if (Physics.Raycast(transform.position, transform.right, 1f, wallLayer))
                {

                    // moveDirection
                    moveDirection += -transform.right * wallJumpForce / 2.5f; // Adjust the divisor for stronger/weaker push.

                }

                // Else If
                else if (Physics.Raycast(transform.position, -transform.right, 1f, wallLayer))
                {

                    // moveDirection
                    moveDirection += transform.right * wallJumpForce / 2.5f;

                }

            }

            // Continue after Ground Jump logic and Wall Jump logic 

            // Else
            else
            {

                // moveDirection - y - movementDirectionY
                moveDirection.y = movementDirectionY;

            }

            // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
            // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
            // as an acceleration (ms^-2)

            // If 
            if (!characterController.isGrounded)
            {

                // moveDirection - y - 
                moveDirection.y -= gravity * Time.deltaTime;

            }

            // Move the controller
            characterController.Move(moveDirection * Time.deltaTime);

            // Player and Camera rotation

            // If - canMove
            if (canMove)
            {

                // rotation
                rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
                rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);

                // playerCamera - transform -localRotation
                playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

                // transform - rotation
                transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);

            }

            // Crouch - Crouching

            // Check for the crouch key press and toggle the isCrouching variable

            // If - Input - GetKeyDown - KeyCode C - And canMove
            if (Input.GetKeyDown(KeyCode.C) && canMove)
            {

                // isCrouching - !isCrouching
                isCrouching = !isCrouching;

                // If - isCrouching
                if (isCrouching)
                {

                    // characterController - height - crouchHeight
                    characterController.height = crouchHeight;

                    // walkingSpeed - crouchSpeed
                    walkingSpeed = crouchSpeed;

                }

                // Else
                else
                {

                    // characterController - height - originalHeight
                    characterController.height = originalHeight;

                    // walkingSpeed -  7.5f
                    walkingSpeed = 7.5f;

                }

            }

            // Implement the smooth transition for the cameras position between crouching and standing

            // If - isCrouching
            if (isCrouching)
            {

                // playerCamera - transform - localPosition
                playerCamera.transform.localPosition = Vector3.Lerp(playerCamera.transform.localPosition, cameraCrouchPosition, crouchTransitionSpeed * Time.deltaTime);

            }

            // Else
            else
            {

                // playerCamera - transform - localPosition
                playerCamera.transform.localPosition = Vector3.Lerp(playerCamera.transform.localPosition, cameraStandPosition, crouchTransitionSpeed * Time.deltaTime);

            }

            // Wall Jump - Wall Jumping

            // Wall Jump - Detect walls
            RaycastHit hit;

            // If
            if (Physics.Raycast(transform.position, transform.right, out hit, 1f, wallLayer) || Physics.Raycast(transform.position, -transform.right, out hit, 1f, wallLayer))
            {

                // isTouchingWall - true
                isTouchingWall = true;

            }

            // Else
            else
            {

                // isTouchingWall - false
                isTouchingWall = false;

            }

        } // Close - Update

    } // Close - Public - Class - TestStuff_FPSController

} // Close - Namespace - TestStuff_FPSController
