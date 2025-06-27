using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicInGame : MonoBehaviour
{
    public AudioSource AS;
    public MusicContr MC;
    static float savegrom;
    // Start is called before the first frame update
    void Start()
    {
        savegrom = MC.saveVolForGame;
        AS.volume = savegrom;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
