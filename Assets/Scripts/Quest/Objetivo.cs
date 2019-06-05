using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Objetivo
{
    public QuestType type;
    public float cuantitive;
    public string _class;
    public bool completed;

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

 
