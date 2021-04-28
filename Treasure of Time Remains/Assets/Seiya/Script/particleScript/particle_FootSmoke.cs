using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class particle_FootSmoke : MonoBehaviour
    {
        ThirdPersonCharacter m_charcter;
        [SerializeField]
        GameObject m_player;
        private ParticleSystem footsmoke;
        // Start is called before the first frame update
        private void Start()
        {
            m_charcter = m_player.GetComponent<ThirdPersonCharacter>();
            footsmoke = GetComponent<ParticleSystem>();
        }
        // Update is called once per frame
        void Update()
        {

            if (m_charcter.m_IsGrounded)
            {
                footsmoke.Play();
            }
            else
            {
                footsmoke.Stop();

            }
        }
    }
}
