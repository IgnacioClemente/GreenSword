using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Escalones : TriggerNextQuest
{
    public GameObject[] stairs;
    public GameObject escalones;
    public int timebetweenstairs = 2;
    float contador;
    int index;

    void Update()
    {
        if (active)
        {
            contador += Time.deltaTime;
            if (contador > timebetweenstairs)
            {
                contador = 0;
                stairs[index].SetActive(true);
                index++;
            }
            if (stairs.Length == index)
            {
                active = false;
            }
        }
    }
}
