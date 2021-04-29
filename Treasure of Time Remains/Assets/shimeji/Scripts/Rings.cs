using UnityEngine;
using Chronos;

public class Rings : MonoBehaviour
{
    GameObject TimeKeeper;
    GlobalClock[] gc = new GlobalClock[2];
    public float x;
    public float y;
    public float z;


    void Start()
    {
        TimeKeeper = GameObject.Find("Timekeeper");
        gc = TimeKeeper.GetComponents<GlobalClock>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float multiplier = gc[1].timeScale;
        Vector3 rotAngles = new Vector3(x * multiplier, y * multiplier, z * multiplier);

        transform.Rotate(rotAngles);
    }
}
