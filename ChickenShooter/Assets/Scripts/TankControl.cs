using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControl : MonoBehaviour
{
    public float forceMultiplier = 1000.0f;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");

//        Vector2 force = new Vector2(hAxis * forceMultiplier, 0);

        Vector2 force = transform.right * hAxis * forceMultiplier * (60.0f * Time.deltaTime);

        rb.AddForce(force);
    }
}
