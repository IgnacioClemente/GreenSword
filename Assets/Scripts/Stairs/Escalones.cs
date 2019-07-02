using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Escalones : MonoBehaviour
{

    public GameObject[] stairs;
    public GameObject escalones;
    public string RelatedQuestName;
    public bool active;
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
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<PlayerController>()!=null)
        {
            if (QuestManager.Instance.ActiveQuest._name == RelatedQuestName)
            {
                QuestManager.Instance.CheckActiveQuest(CharacterType.ERROR, RelatedQuestName);
                active = true;
            }
        }
    }
}
