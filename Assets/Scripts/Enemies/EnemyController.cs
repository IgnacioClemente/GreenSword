using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class EnemyController : CharacterBase
{
    [SerializeField] float attackDistance = 8;
    [SerializeField] float chaseDistance = 18;
    [SerializeField] float timeToStopChasing = 5;
    [SerializeField] LayerMask layersToHit;

    private Transform playerTransform;
    private float playerDistance;
    private bool tookDamage;
    private RaycastHit hit;
    private List<Transform> patrolPoints;
    private Transform actualPatrolPoint;
    private GameObject explotion;


    public EnemyController(string name, string desc, CharacterType type) : base(name, desc, type)
    {
    }

    private void Awake()
    {
        
    }

    private void Start()
    {
        playerTransform = GameManager.Instance.Player.transform;
    }

    void Update()
    {
        if (gameObject.activeSelf) //si esta activo
        {
            playerDistance = Vector3.Distance(playerTransform.position, transform.position);// calculo la distancia del player

            if (tookDamage || playerDistance < chaseDistance)// si tome daño o mi distancia es menor que chase distance
            {
                LookAtPlayer();//miro al player

                if (playerDistance > attackDistance)//si la distancia del player es mayor a mi distancia de ataque lo persigo
                    ChasePlayer();
            }
            //else
                //Patrol();
        }
    }

    public void LookAtPlayer()
    {
        transform.LookAt(playerTransform.position);
        //transform.forward = (playerTransform.position - transform.position).normalized;

        if (Physics.Raycast(transform.position, transform.forward, out hit, chaseDistance, layersToHit))
        {
            GameObject hitobject = hit.transform.gameObject;
           // if (hitobject.GetComponent<PlayerController>()) 
               // attack.Shoot();
        }
    }
    public void ChasePlayer()
    {
        Debug.Log((playerTransform.position - transform.position).normalized);
       transform.position += (playerTransform.position - transform.position).normalized * playerStats.speed * Time.deltaTime;
    }

    public void SetEnemy(List<Transform> patrols, Transform spawnPoint)
    {
        patrolPoints = patrols;
        transform.position = spawnPoint.position;
        actualPatrolPoint = patrolPoints[Random.Range(0, patrolPoints.Count - 1)];
    }

    public void Patrol()
    {
        if (Vector3.Distance(actualPatrolPoint.position, transform.position) < 2)
        {
            actualPatrolPoint = GetNewPatrolPoint();
        }
        transform.Translate((actualPatrolPoint.position - transform.position).normalized * playerStats.speed * Time.deltaTime);
    }

    private Transform GetNewPatrolPoint()
    {
        //Busco un random, si es distinto a acualpatrolpoint, lo retorno, si no vuelvo a llamar esta funcion
        Transform auxPatrolPoint = patrolPoints[Random.Range(0, patrolPoints.Count - 1)];
        if (auxPatrolPoint == actualPatrolPoint)
        {
            auxPatrolPoint = GetNewPatrolPoint();
        }

        return auxPatrolPoint;
    }

    //quest
    public void weaponDrop()
    {


    }
    public void ChageStates()
    {

    }

    public void Ondeath()
    {
        QuestManager.Instance.CheckActiveQuest(type);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Ondeath();
            gameObject.SetActive(false);
        }
    }

    public void Attack()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage()
    {
        throw new System.NotImplementedException();
    }
}

