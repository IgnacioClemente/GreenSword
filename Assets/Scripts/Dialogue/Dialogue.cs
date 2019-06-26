using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField] Sentence[] sentences;
    [SerializeField] string npcName;
    [SerializeField] EnemySpawner spawner;

    public Sentence[] Sentences { get { return sentences; } }
    public string NpcName { get { return npcName; } }

    //Se va a llamar cuando el player arranque este dialogo especifico por algun trigger que pongamos
    public void StartDialogue()
    {
        if (spawner != null) spawner.ActivateEnemies();
        DialogueManager.Instance.StartDialogue(this);
    }

    public void End()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            StartDialogue();
    }
}
