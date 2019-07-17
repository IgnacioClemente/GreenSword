using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class EnemyDeathEvent : UnityEvent<EnemyController> { }

public class EnemyController : CharacterBase
{
    [SerializeField] float attackDistance = 8;
    [SerializeField] float chaseDistance = 18;
    [SerializeField] float timeToStopChasing = 5;

    private float playerDistance;
    private bool tookDamage;
    private bool isDead;
    private float actualSpeed;
    private EnemyDeathEvent onEnemyDeath;

    protected Vector3 moveDir;
    protected Animator anim;
    protected PlayerController player;

    public EnemyDeathEvent OnEnemyDeath { get { return onEnemyDeath; } }


    public EnemyController(string name, string desc, CharacterType type) : base(name, desc, type)
    {
    }

    private void Awake()
    {
        onEnemyDeath = new EnemyDeathEvent();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        player = GameManager.Instance.Player;
        canAttack = true;
    }

    void Update()
    {
        anim.SetFloat("Speed", actualSpeed);
        if (isDead) return;
        if (gameObject.activeSelf) //si esta activo
        {
            actualSpeed = 0;
            playerDistance = Vector3.Distance(player.transform.position, transform.position);// calculo la distancia del player

            if (tookDamage || playerDistance < chaseDistance)// si tome daño o mi distancia es menor que chase distance
            {
                LookAtPlayer();//miro al player

                if (playerDistance > attackDistance)//si la distancia del player es mayor a mi distancia de ataque lo persigo
                    ChasePlayer();
                else if(canAttack)
                    Attack();
            }
        }
    }

    public void LookAtPlayer()
    {
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
    }

    public void ChasePlayer()
    {
        actualSpeed = characterStats.speed * 2;
        moveDir = (player.transform.position - transform.position).normalized * actualSpeed * Time.deltaTime;
        transform.position += new Vector3(moveDir.x, 0, moveDir.z);
    }

    protected override void OnDeath()
    {
        isDead = true;
        anim.SetBool("Dead", isDead);
        anim.SetTrigger("Die");
        onEnemyDeath.Invoke(this);
        player.characterStats.xp += characterStats.xp;
        QuestManager.Instance.CheckActiveQuest(type);
        base.OnDeath();
    }

    protected virtual void Attack()
    {
        anim.SetTrigger("Attack");
        player.TakeDamage(characterStats.ataque, this);
        canAttack = false;
        Invoke("AllowAttack", 10 / characterStats.destreza);
    }

    public override void TakeDamage(float damage, EnemyController damager = null)
    {
        if (isDead)
            return;

        anim.SetTrigger("TakeDamage");
        base.TakeDamage(damage, damager);
    }
}

