using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{
    public float coinsCount;
    public Text txt;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        txt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "Score:" + coinsCount.ToString();
    }
}
