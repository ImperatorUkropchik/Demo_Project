using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LeveliScripti : MonoBehaviour
{
    //public Button Butt;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void LevelZapusk(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
