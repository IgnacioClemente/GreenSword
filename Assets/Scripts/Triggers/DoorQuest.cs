using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DoorQuest : TriggerNextQuest
{
    [SerializeField] private Animator anim;

    protected override void ActivateTrigger()
    {
        base.ActivateTrigger();
        anim.SetBool("OpenDoor", active);
    }
}
