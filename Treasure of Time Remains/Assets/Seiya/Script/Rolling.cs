using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rolling : MonoBehaviour
{

    [SerializeField]
    private GameObject effectPrefab;
    //public AudioClip itemGet;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(new Vector3(90, 0, 0) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //AudioSource.PlayClipAtPoint(itemGet, transform.position);
            Destroy(this.gameObject);

            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);

            Destroy(effect, 2.0f);
        }
    }
}
