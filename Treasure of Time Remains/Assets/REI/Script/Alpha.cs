using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alpha : MonoBehaviour
{
    private float alpha = 1;
    private float flg = 1;

    [SerializeField] private Image button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        alpha -= Time.deltaTime * flg;
        if (alpha <= 0) { alpha = 0; flg *= -1; }
        if (alpha >= 1) { alpha = 1; flg *= -1; }

        button.color = new Color(1, 1, 1, alpha);
    }
}
