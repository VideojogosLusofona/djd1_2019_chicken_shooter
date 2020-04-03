using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float        speed = 100;
    public float        radius = 200.0f;
    public float        forceMultiplier = 5000.0f;
    public GameObject   explosionPrefab;

    Rigidbody2D rb;
    bool        enableRotation = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (enableRotation)
        {
            Vector3 forward = Vector3.forward;
            Vector3 upwards = Vector3.up;
            Vector3 direction = rb.velocity;

            if (direction.x < 0) forward = -forward;

            upwards = Vector3.Cross(forward, direction);

            transform.rotation = Quaternion.LookRotation(forward, upwards);
        }

//        transform.position = transform.position + transform.right * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        enableRotation = false;

        //Explode();

        Invoke("Explode", 5.0f);
    }

    void Explode()
    {
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, transform.rotation);
        }

        Destroy(gameObject);

        Bullet[] bullets = GameObject.FindObjectsOfType<Bullet>();

        foreach (Bullet chicken in bullets)
        {
            float distance = Vector3.Distance(chicken.transform.position, transform.position);
            if (distance < radius)
            {
                Rigidbody2D rb = chicken.GetComponent<Rigidbody2D>();

                Vector2 force = (chicken.transform.position - transform.position + Vector3.up * 100.0f).normalized * forceMultiplier;

                rb.AddForce(force, ForceMode2D.Impulse);
                
                //Destroy(chicken.gameObject);
            }
        }
    }
}
