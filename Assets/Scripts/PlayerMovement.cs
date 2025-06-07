using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveH, moveV;
    public float moveSpeed = 1.0f;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Awake()
    {
        
    }
    private void FixedUpdate()
    {
        moveH = Input.GetAxis("Horizontal") * moveSpeed;
        moveV = Input.GetAxis("Vertical") * moveSpeed;
        rb.velocity = new Vector2(moveH, moveV);

        Vector2 direction = new Vector2(moveH, moveV);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
