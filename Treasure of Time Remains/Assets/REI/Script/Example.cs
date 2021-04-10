using UnityEngine;

public class Example : MonoBehaviour
{
    public CameraShake shake;

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    shake.Shake(0.25f, 0.25f);
        //}
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fall")
        {
            shake.Shake(0.25f, 0.25f);
        }

    }
}