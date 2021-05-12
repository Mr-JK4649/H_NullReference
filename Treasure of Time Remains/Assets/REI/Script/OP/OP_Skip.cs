using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OP_Skip : MonoBehaviour
{
    [SerializeField] private OPSceneMovie OPSM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(OPSM.presskeyFrames * 2, 15);
    }
}
