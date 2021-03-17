using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSlide : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        this.gameObject.transform.position += new Vector3(0, 0, speed);
    }
}
