using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertEffect : MonoBehaviour
{
    public Material material;
    private Color ori;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private void FixedUpdate()
    {
        //if (Input.GetKey(KeyCode.F))
            
            
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {

        Graphics.Blit(src, dest, material);
    }
}
