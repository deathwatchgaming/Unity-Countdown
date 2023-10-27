// Using - Engine
using UnityEngine;

// Namespace - DWG.TestStuff_FPSController
namespace DWG.TestStuff_FPSController
{

    // Public - Class - TestStuff_HeadBobber
    public class TestStuff_HeadBobber : MonoBehaviour
    {

        // Public - Float - walkingBobbingSpeed - 14
        public float walkingBobbingSpeed = 14f;

        // Public - Float - bobbingAmount - 0.05
        public float bobbingAmount = 0.05f;

        // Public - TestStuff_FPSController - Controller
        public TestStuff_FPSController controller;

        // Float - defaultPosY - 0
        float defaultPosY = 0;

        // Float - timer - 0
        float timer = 0;

        // Start Is Called Before The First Frame Update

        // Void -Start
        public void Start()
        {

        	// defaultPosY - Transform - localPosition - Y
            defaultPosY = transform.localPosition.y;

        } // Close - Void - Start

        // Update Is Called Once Per Frame

        // Void - Update
        public void Update()
        {

        	// If
        	if (Mathf.Abs(controller.moveDirection.x) > 0.1f || Mathf.Abs(controller.moveDirection.z) > 0.1f)
        	{

        		// Player Is Moving

        		// timer
        		timer += Time.deltaTime * walkingBobbingSpeed;

        		//transform.localPosition
        		transform.localPosition = new Vector3
        		(transform.localPosition.x, defaultPosY + Mathf.Sin
        		(timer) * bobbingAmount, transform.localPosition.z);

        	} // Close - If

        	// Else
            else
            {

            	// Idle

            	// Timer
            	timer = 0;

            	// transform.localPosition
                transform.localPosition = new Vector3
                (transform.localPosition.x, Mathf.Lerp
                (transform.localPosition.y, defaultPosY, Time.deltaTime *
                walkingBobbingSpeed), transform.localPosition.z);
                
            } // Close - Else


        } // Close- Void -Update

    } // Close - Public - Class - TestStuff_HeadBobber

} // Close - Namespace - DWG.TestStuff_FPSController	