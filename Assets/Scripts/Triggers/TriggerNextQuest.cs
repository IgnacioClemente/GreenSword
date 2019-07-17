using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNextQuest : MonoBehaviour
{
    public string RelatedQuestName;
    public bool active;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            if (QuestManager.Instance.ActiveQuest._name == RelatedQuestName)
            {
                QuestManager.Instance.CheckActiveQuest(CharacterType.ERROR, RelatedQuestName);
                ActivateTrigger();
            }
        }
    }

    protected virtual void ActivateTrigger()
    {
        active = true;
    }
}