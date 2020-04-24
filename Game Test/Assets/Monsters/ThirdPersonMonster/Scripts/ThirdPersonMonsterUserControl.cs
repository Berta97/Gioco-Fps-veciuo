using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace Monster.ThirdPersonMonster
{
    [RequireComponent(typeof(ThirdPersonMonster))]
    public class ThirdPersonMonsterUserControl : MonoBehaviour
    {
        private ThirdPersonMonster monster;         // A reference to the ThirdPersonCharacter on the object
        private Transform mainCam;                  // A reference to the main camera in the scenes transform
        private Vector3 camForward;                // The current forward direction of the camera
        private Vector3 move;

        // Start is called before the first frame update
        void Start()
        {
            // get the transform of the main camera
            if (Camera.main != null)
            {
                mainCam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
                // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
            }

            // get the third person character ( this should never be null due to require component )
            monster = GetComponent<ThirdPersonMonster>();
        }

        // Fixed update is called in sync with physics
        private void FixedUpdate()
        {
            // read inputs
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");

            // calculate move direction to pass to character
            if (mainCam != null)
            {
                // calculate camera relative direction to move:
                camForward = Vector3.Scale(mainCam.forward, new Vector3(1, 0, 1)).normalized;
                move = v * camForward + h * mainCam.right;
            }
            else
            {
                // we use world-relative directions in the case of no main camera
                move = v * Vector3.forward + h * Vector3.right;
            }
#if !MOBILE_INPUT
            // walk speed multiplier
            if (Input.GetKey(KeyCode.LeftShift)) move *= 0.5f;
#endif

            // pass all parameters to the character control script
            monster.Move(move);
        }
    }
}

