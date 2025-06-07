using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private PlayerMovement pM;
    public float CoinCount;
    public GameObject pl;
    private CoinController CC;
    public GameObject CoCo;
    // Start is called before the first frame update
    void Start()
    {
        CoCo = GameObject.Find("ScoreTxt");
        pl = GameObject.Find("Player");
        CC = CoCo.GetComponent<CoinController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            CC.coinsCount++;
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
