using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MusicContr : MonoBehaviour
{
    public Slider slid;
    public AudioSource asS;
    public GameObject risa;
    private bool iszvikl = false;
    private float saveVol;
    static float saveVole;
    public float saveVolForGame;
    // Start is called before the first frame update
    void Start()
    {
        saveVolForGame = saveVole;
    }

    // Update is called once per frame
    void Update()
    {
        if(asS != null)
        {
            asS.volume = slid.value;
            if (asS.volume == 0) risa.SetActive(true);
            else risa.SetActive(false);
            if (slid.value != 0) iszvikl = false;
            saveVole = asS.volume;
        }
    }
    public void Zvuk()
    {
        if (asS.volume != 0 && iszvikl == false)
        {
            saveVol = asS.volume;
            slid.value = 0;
            iszvikl = true;
            Debug.Log(iszvikl);
            Debug.Log(saveVol);
        }
        else if (asS.volume == 0 && iszvikl == true)
        {
            slid.value = saveVol;
            iszvikl = false;
        }
    }

}
