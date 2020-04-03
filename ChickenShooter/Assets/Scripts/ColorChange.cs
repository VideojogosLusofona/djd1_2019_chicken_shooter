using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Color startColor;

    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = startColor;
    }

    private void Update()
    {
        Color color;

        color = Color.HSVToRGB(Random.Range(0.0f, 1.0f), Random.Range(0.5f, 1.0f), Random.Range(0.5f, 1.0f));

        spriteRenderer.color = color;
    }
}
