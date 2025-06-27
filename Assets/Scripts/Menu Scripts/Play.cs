using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    //public TMP_InputField inputField;
    private string trimmed;
    private string pasword = "secretcode";
    public WeaponData WD;
    public GameObject SuccesT;
    // Start is called before the first frame update
    void Start()
    {
        WD.boolInfo = false;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void takeInputText(string input)
    {
        trimmed = input.Trim().ToLower();
        if(trimmed == pasword)
        {
            //GameObject Go = GameObject.Find("PlayBut");
            //PlayerMovement PM = Go.GetComponent<PlayerMovement>();
            WD.boolInfo = true;
            Debug.Log(WD.boolInfo);
            Succes();
        }
    }
    private void Succes()
    {
        SuccesT.SetActive(true);
        Invoke("Vikl", 3f);
    }
    private void Vikl()
    {
        SuccesT.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
