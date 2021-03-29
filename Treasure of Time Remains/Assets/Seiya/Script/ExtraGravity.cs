using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ExtraGravity : MonoBehaviour
{
    public float Multiplier = 1f;

    private Rigidbody Rigidbody;

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Rigidbody.AddForce((Multiplier - 1f) * Physics.gravity, ForceMode.Acceleration);
    }
}
