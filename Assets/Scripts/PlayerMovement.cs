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
    private bool playerCanMove = true;

    private bool isConsolOpen = false;
    public GameObject consol;
    public WeaponData WD;

    public Transform TochkaTP;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log(WD.boolInfo);
    }
    private void Awake()
    {
        
    }
    private void FixedUpdate()
    {
        HpTxt.text = HP.ToString();
        if (playerCanMove)
        {
            moveH = Input.GetAxis("Horizontal") * moveSpeed;
            moveV = Input.GetAxis("Vertical") * moveSpeed;
            rb.velocity = new Vector2(moveH, moveV);
            Vector2 direction = new Vector2(moveH, moveV);
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("teleporta"))
        {
            transform.position = TochkaTP.position;
        }
    }
    public void Damage(Vector3 enemyPos)
    {
        HP--;
        Vector3 impulse = enemyPos - transform.position;
        transform.Translate(-impulse * 1f);
        if (HP <= 0)
        {
            SceneManager.LoadScene(0);
            //Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Slash))
        {
            if (WD.boolInfo == true)
            {
                Debug.Log(WD.boolInfo);
                if (isConsolOpen)
                {
                    consol.SetActive(false);
                    isConsolOpen = !isConsolOpen;
                    playerCanMove = !playerCanMove;
                }
                else
                {
                    consol.SetActive(true);
                    isConsolOpen = !isConsolOpen;
                    playerCanMove = !playerCanMove;
                    rb.velocity = new Vector2(0, 0);
                }
            }
        }
    }
}
