using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    [SerializeField] PlayerController player;
    [SerializeField] Text dialogueText;
    [SerializeField] GameObject dialogueBackGround;
    

    private Dialogue actualDialogue;
    private int index;
    private List<EnemyController> enemiesList = new List<EnemyController>();

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        Instance = this;

        dialogueBackGround.SetActive(false);
    }

    public void AddEnemy(EnemyController enemy)
    {
        enemiesList.Add(enemy);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        index = 0;
        actualDialogue = dialogue;
        dialogueBackGround.SetActive(true);
        player.InDialogue = true;
        //enemies del actual dialogue stop
        //start first sentence
        ChangeText(actualDialogue.Sentences[index]);
    }

    public void NextSentence()
    {
        index++;

        if (actualDialogue.Sentences.Length <= index)
            EndDialogue();
        else
            ChangeText(actualDialogue.Sentences[index]);
    }

    private void ChangeText(Sentence sentence)
    {
        //Esto es un if ternario, una forma de poner un if else en una sola linea
        //La condicion va antes del signo de pregunta
        //Si se cumple, ocurre lo que va antes del dos puntos, si no lo que va despues
        dialogueText.text = sentence.NpcGoesFirst ?
                            actualDialogue.NpcName + ": " + sentence.NpcSentence + "\n\r" + player._name + ": " + sentence.PlayerSentence :
                            player._name + ": " + sentence.PlayerSentence + "\n\r" + actualDialogue.NpcName + ": " + sentence.NpcSentence;
    }

    private void EndDialogue()
    {
        dialogueBackGround.SetActive(false);
        actualDialogue.End();
        player.InDialogue = false;
        //enemies del actual dialogue play
    }
}
