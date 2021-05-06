using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class AutoPlay : MonoBehaviour
    {
        private ThirdPersonUserControl chara;

        public bool floorLoop;

        private void Start()
        {
            chara = this.gameObject.GetComponent<ThirdPersonUserControl>();
        }

        private void OnTriggerExit(Collider other)
        {
            if (floorLoop && other.gameObject.tag != "AutoJump" && other.gameObject.tag != "AutoDash") {
                GameObject inst = other.gameObject;
                float len = inst.transform.GetChild(0).localScale.z;
                //float z = inst.transform.position.z + len * 2;
                float z = inst.transform.position.z + len;
                Destroy(other.gameObject);

                
                
                Instantiate(inst, new Vector3(0,0,z),Quaternion.identity);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "AutoJump") {
                chara.JumpYeah();
            }

            if (other.gameObject.tag == "AutoDash") {
                chara.DashYeah();
            }
        }
    }

}