using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Effects
{
    public class ExplosionPhysicsForce : MonoBehaviour
    {
        public float explosionForce = 4;

        //�J�E���g�A�b�v
        private float countup = 0.0f;

        //�^�C�����~�b�g
        public float timeLimit = 5.0f;


        private IEnumerator Start()
        {
            if (countup >= timeLimit)
            {
                // wait one frame because some explosions instantiate debris which should then
                // be pushed by physics force
                yield return null;

            float multiplier = GetComponent<ParticleSystemMultiplier>().multiplier;

            float r = 10*multiplier;
            var cols = Physics.OverlapSphere(transform.position, r);
            var rigidbodies = new List<Rigidbody>();

                foreach (var col in cols)
                {
                    if (col.attachedRigidbody != null && !rigidbodies.Contains(col.attachedRigidbody))
                    {
                        rigidbodies.Add(col.attachedRigidbody);
                    }
                }
                foreach (var rb in rigidbodies)
                {
                    rb.AddExplosionForce(explosionForce * multiplier, transform.position, r, 1 * multiplier, ForceMode.Impulse);
                }
            }
        }

        private void Update()
        {

            //���Ԃ��J�E���g����
            countup += Time.deltaTime;

        }

    }
}
