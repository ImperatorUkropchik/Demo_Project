using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInGame : MonoBehaviour
{
    public AudioSource AS;
    public AudioContr AC;
    static float savegrom;
    // Start is called before the first frame update
    void Start()
    {
        savegrom = AC.saveVolForGame;
        AS.volume = savegrom;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
