using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private Renderer background;
    private Vector2 textureOffset;

    void Start()
    {
        background = GetComponent<Renderer>();
    }


    void Update()
    {
        textureOffset.x += Time.deltaTime * 0.1f;
        background.material.mainTextureOffset = textureOffset;
    }
}
