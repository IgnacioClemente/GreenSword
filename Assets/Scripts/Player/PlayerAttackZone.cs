using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackZone : MonoBehaviour
{
    private List<EnemyController> enemyList;

    public List<EnemyController> EnemyList { get { return enemyList; } }

    private void Awake()
    {
        enemyList = new List<EnemyController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            var aux = other.GetComponent<EnemyController>();
            if (aux != null)
            {
                aux.OnEnemyDeath.AddListener(RemoveEnemy);
                enemyList.Add(aux);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            var aux = other.GetComponent<EnemyController>();
            if (aux != null)
            {
                aux.OnEnemyDeath.RemoveListener(RemoveEnemy);
                enemyList.Remove(aux);
            }
        }
    }

    private void RemoveEnemy(EnemyController enemy)
    {
        if (enemyList.Contains(enemy))
        {
            enemyList.Remove(enemy);
        }
    }
}
