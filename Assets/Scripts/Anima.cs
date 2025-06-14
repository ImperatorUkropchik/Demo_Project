using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Anima : MonoBehaviour
{
    private bool TimeForTema = false;
    public Image tema;
    private float temka = 255f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("PereZatem", 0.5f);
    }
    IEnumerator Zatema()
    {
        while (TimeForTema)
        {
            tema.color = new Color(0f, 0f, 0f, temka);
            temka -= 1f;
            if(temka >= 1f)
            {
                TimeForTema = false;
            }
            yield return new WaitForSeconds(0.1f);
        }

    }
    void PereZatem()
    {
        TimeForTema = true;
        StartCoroutine(Zatema());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
