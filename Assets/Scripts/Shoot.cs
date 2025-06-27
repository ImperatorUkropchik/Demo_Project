using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    public float maxBul;
    public float bulAmount;
    public Text txt;
    public AudioSource AS;
    public AudioClip[] AC;
    public int ammoAdd;
    void Start()
    {
        bulAmount = maxBul;
        txt.text = $"{bulAmount} / { maxBul}";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(bulAmount >= 1)
            {
                Instantiate(bullet, transform.position, transform.rotation);
                bulAmount--;
                txt.text = $"{bulAmount} / { maxBul}";
                int index = AC.Length;
                int g = Random.Range(0, index);
                AS.PlayOneShot(AC[g]);
            }
        }
    }
    public void Obnov()
    {
        bulAmount += ammoAdd;
        if(bulAmount > maxBul)
        {
            bulAmount = maxBul;
        }
        txt.text = $"{bulAmount} / { maxBul}";
    }
    public void Obnovka()
    {
        if (bulAmount > maxBul) maxBul = bulAmount;
        txt.text = $"{bulAmount} / { maxBul}";
    }
}
