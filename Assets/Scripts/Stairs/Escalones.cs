using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Escalones : MonoBehaviour
{

    public GameObject[] stairs;
    public GameObject escalones;
    public bool active;
    public int timebetweenstairs = 2;
    float contador;
    int index;
    QuestManager questmanager;
    JsonManager jsonmanager;

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
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<PlayerController>()!=null)
        {
            if(questmanager.finishedQuests("Quest1"))
            {
                Quest auxQ = jsonmanager.Getquest("Quest2");
                questmanager.AddQuest(auxQ);
                escalones.SetActive(!escalones.activeSelf);
                Destroy(this.GetComponent<BoxCollider>());
            }

            if(questmanager.finishedQuests("Quest2"))
            {
                Quest auxQ = jsonmanager.Getquest("Quest3");
                questmanager.AddQuest(auxQ);
            }

            if (questmanager.finishedQuests("Quest3"))
            {
                Quest auxQ = jsonmanager.Getquest("Quest4");
                questmanager.AddQuest(auxQ);
            }

            if (questmanager.finishedQuests("Quest4"))
            {
                Quest auxQ = jsonmanager.Getquest("Quest5");
                questmanager.AddQuest(auxQ);
            }

            if (questmanager.finishedQuests("Quest5"))
            {
                Quest auxQ = jsonmanager.Getquest("Quest6");
                questmanager.AddQuest(auxQ);
            }

            if (questmanager.finishedQuests("Quest6"))
            {

            }
            //questmanager.AddQuest(jsonmanager.Getquest("Quest2")); //LO mismo que las 2 sentencias de arriba
        }
    }
}
