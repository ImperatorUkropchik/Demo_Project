using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Anima : MonoBehaviour
{
    public Image tema;
    private float temka = 1f;
    public GameObject player;
    public GameObject camira;
    private bool nado = true;
    private bool nnado = true;
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("PereZatem", 0.5f);
        StartCoroutine(Zatema());
        //camira.transform.position = new Vector3(20f, player.transform.position.y, -10f);
    }
    private IEnumerator Zatema()
    {
        while (nado == true)
        {
            tema.color = new Color(0f, 0f, 0f, temka);
            temka -= 0.025f;
            if(temka <= 0f)
            {
                StopCoroutine(Zatema());
                nado = false;
                Debug.Log(tema.color.a);
                Invoke("CamAn", 1f);

            }

            yield return new WaitForSeconds(0.05f);
        }
    }
    private IEnumerator CamAnima()
    {
        float x;
        x = camira.transform.position.x;
        while (nnado == true)
        {
            Debug.Log(tema.color.a);
            camira.transform.position = new Vector3(x, player.transform.position.y, -10f);
            x -= 0.1f;
            if(x <= player.transform.position.x)
            {
                StopCoroutine(CamAnima());
                nnado = false;
            }
            yield return new WaitForSeconds(0.01f);
        }

    }
    void CamAn()
    {
        StartCoroutine(CamAnima());
    }
    void PereZatem()
    {
        //TimeForTema = true;
        //StartCoroutine(Zatema());
    }
    // Update is called once per frame
    void Update()
    {

    }
}
