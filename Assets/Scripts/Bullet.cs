using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb2;
    public float shootForce;
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        rb2.AddForce(transform.right * shootForce, ForceMode2D.Impulse);
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
