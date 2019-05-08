using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetivo : MonoBehaviour
{
    public QuestType type;
    public float cuantitive;
    public float _class;

    public enum QuestType
    {
       matar, caminar, ERROR
    }
   /*bool checkCaminar()
    {
       //Checkear con un box collider y un tag
       //Camina hacia un box y detecta el tag jugador y se completa la quest
    }
    bool checkmatar()
    {
        // checkear con un contador
    }
   public bool Compleat()
    {
        switch (type)
        {
            case QuestType.caminar:
               /* bool listo = checkCaminar();
                return listo;*/
               /* return checkCaminar();
            case QuestType.matar:
                return checkmatar();
            default:
                return false;
        }
    }*/
}

 
