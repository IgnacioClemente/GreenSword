using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestType
{
    matar, caminar, ERROR
}

[System.Serializable]
public class Objetivo
{
    public QuestType type;
    public int cuantitive;
    public CharacterType _class;
    public bool completed;

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

 
