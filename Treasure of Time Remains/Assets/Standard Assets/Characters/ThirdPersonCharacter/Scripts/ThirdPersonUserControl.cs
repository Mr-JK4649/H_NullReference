using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;
using System.Collections.Generic;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class ThirdPersonUserControl : MonoBehaviour
    {
        
        private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
        private Transform m_Cam;                  // A reference to the main camera in the scenes transform
        private Vector3 m_CamForward;             // The current forward direction of the camera
        private Vector3 m_Move;
        private bool m_Jump;      // the world-relative desired move direction, calculated from the camForward and user input.
        
        //4月13日 担当者ZAHA _animation_jump_flg追加  
        public bool _animetion_jump_flg;
        [SerializeField] private Animator ethan;

        
        private void Start()
        {
            // get the transform of the main camera
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
                // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
            }

            // get the third person character ( this should never be null due to require component )
            m_Character = GetComponent<ThirdPersonCharacter>();

        }


        private void Update()
        {
            if (!m_Jump)
            {
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }

            //担当者 ZAHA 編集↓4月13日 追加
            _animetion_jump_flg = CrossPlatformInputManager.GetButtonDown("Jump");
            if (_animetion_jump_flg)
            {
                //m_Character.m_Animator.SetBool("Jumpflg", true);
            }
            else
            {
                //m_Character.m_Animator.SetBool("Jumpflg", false);
            }

            /////////////////////////////////////////////////////////////////////////////////
            if (Input.GetKeyDown("x") || Input.GetButtonDown("Action2"))
            {
                m_Character._input_get = true;
            }
        }


        public float ethan_speed;

        // Fixed update is called in sync with physics
        private void FixedUpdate()
        {
            // read inputs
            //float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float h = 0;
            //プレイヤーが加速し続ける
            ethan_speed = ethan.GetFloat("Speed");
            float v = ethan_speed;
            //float v = CrossPlatformInputManager.GetAxis("Vertical");
            bool crouch = Input.GetKey(KeyCode.C);

            // calculate move direction to pass to character
            if (m_Cam != null)
            {
                // calculate camera relative direction to move:
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = v * m_CamForward + h * m_Cam.right;
            }
            else
            {
                // we use world-relative directions in the case of no main camera
                m_Move = v * Vector3.forward + h * Vector3.right;
            }



#if !MOBILE_INPUT
            // walk speed multiplier
            if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
#endif
            
            // pass all parameters to the character control script
            m_Character.Move(m_Move, crouch, m_Jump);
            m_Jump = false;
        }

        public void JumpYeah() {
            m_Jump = true;
        }

        public void DashYeah() {
            m_Character._input_get = true;
        }
    }
}
