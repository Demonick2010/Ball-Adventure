using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadePlatform : MonoBehaviour
{
    private float duration;
    Color textureColor;
    Material material;
    MeshCollider objectCollider;

    private void Start()
    {
        textureColor = GetComponent<Renderer>().material.color;
        material = GetComponent<Renderer>().material;
        duration = Random.Range(2f, 5f);
        objectCollider = GetComponent<MeshCollider>();
    }

    private void Update()
    {
        textureColor.a = Mathf.PingPong(Time.time, duration) / duration;
        material.color = textureColor;

        if (textureColor.a <= 0.3f && objectCollider.enabled)
            objectCollider.enabled = false;
        else if (textureColor.a >= 0.4f && !objectCollider.enabled)
            objectCollider.enabled = true;
    }
}
