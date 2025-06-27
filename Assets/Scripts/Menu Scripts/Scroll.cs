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
    public GameObject eve;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ScrollToSettings()
    {
        img.transform.DORewind();
        img.transform.DOMoveX(-18.5f, 1.5f);
        pan.transform.DORewind();
        pan.transform.DOMoveX(-20f, 1.5f);
        set.transform.DORewind();
        set.transform.DOMoveX(6f, 1.5f);
    }
    public void ScrollFromSettings()
    {
        img.transform.DORewind();
        img.transform.DOMoveX(0f, 1.5f);
        pan.transform.DORewind();
        pan.transform.DOMoveX(-7f, 1.5f);
        set.transform.DORewind();
        set.transform.DOMoveX(22f, 1.5f);
    }
    public void ScrollToLevels()
    {
        Debug.Log("Sugdgv");
        eve.transform.DORewind();
        eve.transform.DOMoveY(10f, 1.5f);
    }
    public void ScrollFromLevels()
    {
        Debug.Log("Sugdgv");
        eve.transform.DORewind();
        eve.transform.DOMoveY(0f, 1.5f);
    }
}
