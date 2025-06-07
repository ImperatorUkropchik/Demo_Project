using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveH, moveV;
    public float moveSpeed = 1.0f;
    private Rigidbody2D rb;
    public Text CoinTxt;
    public Text HpTxt;
    public float HP;
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
        if(HP <= 0)
        {
            SceneManager.LoadScene(0);
        }
        HpTxt.text = HP.ToString();
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
