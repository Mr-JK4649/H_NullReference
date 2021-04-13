using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class Ground_Slep : MonoBehaviour
    {
        ThirdPersonCharacter third_person_character;
        ThirdPersonUserControl third_person_control;
        GameObject third_person_obj;
        // Start is called before the first frame update
        void Start()
        {
            third_person_obj = GameObject.Find("ThirdPersonController");
            third_person_character = third_person_obj.GetComponent<ThirdPersonCharacter>();
            third_person_control = third_person_obj.GetComponent<ThirdPersonUserControl>();
        }

        private void OnCollisionStay(Collision collision)
        {
            Rigidbody rb;
            rb = collision.rigidbody.GetComponent<Rigidbody>();

            if (!third_person_control._animetion_jump_flg && third_person_character.m_IsGrounded)
            {
                rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.y);
            }
        }
    }
}
