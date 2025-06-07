using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScr : MonoBehaviour
{
    private PlayerMovement PM;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        PM = Player.GetComponent<PlayerMovement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PM.HP--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
