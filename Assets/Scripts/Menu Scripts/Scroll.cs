using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Scroll : MonoBehaviour
{
    public GameObject img;
    public GameObject pan;
    public GameObject set;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ScrollIMG()
    {
        img.transform.DORewind();
        img.transform.DOMoveX(-22, 1.5f);
        pan.transform.DORewind();
        pan.transform.DOMoveX(-20f, 1.5f);
        set.transform.DORewind();
        set.transform.DOMoveX(6f, 1.5f);
    }
    public void ScrollobrIMG()
    {
        img.transform.DORewind();
        img.transform.DOMoveX(1, 1.5f);
        pan.transform.DORewind();
        pan.transform.DOMoveX(-7f, 1.5f);
        set.transform.DORewind();
        set.transform.DOMoveX(22f, 1.5f);
    }
}
