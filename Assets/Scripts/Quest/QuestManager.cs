using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] JsonManager jsonmanager;
    [SerializeField] PlayerController player;

    List<Quest> listQuest;
    List<Quest> listSideQuest;
    List<Quest> activeQuest;
    List<Quest> activeSideQuest;
    List<Quest> toBeRewardedQuest;
    List<Quest> finishQuest;

    void Awake()
    {
        listQuest = new List<Quest>();
        listSideQuest = new List<Quest>();
        activeQuest = new List<Quest>();
        activeSideQuest = new List<Quest>();
        toBeRewardedQuest = new List<Quest>();
        finishQuest = new List<Quest>();
    }

    private void Start()
    {
        activeQuest.Add(jsonmanager.Getquest("Quest1"));
    }

    public void AddSideQuest(Quest sidequest)
    {
        listSideQuest.Add(sidequest);
    }

    public void RemoveSideQuest(Quest sidequest)
    {
        listSideQuest.Remove(sidequest);
        toBeRewardedQuest.Add(sidequest);
    }

    public void AddQuest(Quest quest)
    {
        listQuest.Add(quest);
    }

   public void RemoveQuest(Quest quest)
    {
        listQuest.Remove(quest);
        toBeRewardedQuest.Add(quest);
    }

    void AddReward(Reward reward)
    {
        player.playerStats.xp += reward.xp;
        //player.playerStats.money += reward.money;
        for(int i = 0; i < reward.item.Length;i++)
        {
            player.inventario.itemArray.Add(reward.item[i]);
        }
    }

    public bool finishedQuests(string p_name)
    {
        bool found;
        found = toBeRewardedQuest.Contains(jsonmanager.Getquest(p_name));
        return found;
    }

   /* void Update()
    {
		for(int i = 0;i < activeQuest.Count;i++)
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

        }
    }*/
}
