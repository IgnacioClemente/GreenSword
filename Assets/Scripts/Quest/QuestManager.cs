using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] JsonManager jsonmanager;
    [SerializeField] PlayerController player;

    List<Quest> listQuest;
    List<Quest> listSideQuest;
    Quest activeQuest;
    Quest activeSideQuest;
    List<Quest> toBeRewardedQuest;
    List<Quest> finishedQuests;

    void Awake()
    {
        listQuest = new List<Quest>();
        listSideQuest = new List<Quest>();
        toBeRewardedQuest = new List<Quest>();
        finishedQuests = new List<Quest>();
    }

    private void Start()
    {
        listQuest = jsonmanager.GetQuests();
        listSideQuest = jsonmanager.GetSideQuests();
        ActivateQuest(listQuest[0]);
    }

    public void ActivateQuest(Quest quest)
    {
        if (quest == null) return;

        activeQuest = quest;
        activeSideQuest = GetSideQuest(quest.Queststats.sidequest);
    }

    public void FinishQuest(Quest finishedQuest) 
    {
        AddReward(finishedQuest.reward);
        finishedQuest.obj.completed = true;
        finishedQuests.Add(finishedQuest);
        //Si la quest terminada tiene nextquest, la activo
        if (!string.IsNullOrEmpty(finishedQuest.Queststats.nextquest))
            ActivateQuest(Getquest(finishedQuest.Queststats.nextquest));
    }

    void AddReward(Reward reward)
    {
        player.playerStats.xp += reward.xp;
        /*for(int i = 0; i < reward.item.Length;i++)
        {
            player.inventario.itemArray.Add(reward.item[i]);
        }*/
    }

    public Quest Getquest(string _name)
    {
        for (int i = 0; i < listQuest.Count; i++)
        {
            if (listQuest[i]._name == _name)
            {
                return listQuest[i];
            }
        }
        return null;
    }

    public Quest GetSideQuest(string _name)
    {
        for (int i = 0; i < listSideQuest.Count; i++)
        {
            if (listSideQuest[i]._name == _name)
            {
                return listSideQuest[i];
            }
        }
        return null;
    }

    void Update()
     {
        if (Input.GetKeyDown(KeyCode.J)) FinishQuest(activeQuest);
         /*for(int i = 0;i < activeQuest.Count;i++)
         {
             if(activeQuest[i].obj.Compleat())
             {
                 AddReward(activeQuest[i].reward);
                 toBeRewardedQuest.Remove(activeQuest[i]);
                 finishQuest.Add(activeQuest[i]);
             }
         }
         for (int i = 0; i < activeSideQuest.Count; i++)
         {
             if (activeSideQuest[i].obj.Compleat())
             {
                 AddReward(activeSideQuest[i].reward);
                 toBeRewardedQuest.Remove(activeSideQuest[i]);
                 finishQuest.Add(activeSideQuest[i]);
             }

         }*/
     }
}
