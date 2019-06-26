using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyController baseEnemy;
    [SerializeField] CharacterType enemyType;
    [SerializeField] List<Transform> spawnPoints;

    private List<EnemyController> spawnedEnemies = new List<EnemyController>();

    private void Start ()
    {
        Spawn();
    }

    //Ver de hacer efecto cuando spawnean
    public void Spawn()
    {
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            var auxEnemy = Instantiate(baseEnemy, spawnPoints[i].position, spawnPoints[i].rotation);
            spawnedEnemies.Add(auxEnemy);
            auxEnemy.AddBaseInfo(JsonManager.Instance.GetCharacter(enemyType));
            DialogueManager.Instance.AddEnemy(auxEnemy);
            auxEnemy.gameObject.SetActive(false);
        }
    }

    public void ActivateEnemies()
    {
        for (int i = 0; i < spawnedEnemies.Count; i++)
        {
            spawnedEnemies[i].gameObject.SetActive(true);
        }
    }

}
