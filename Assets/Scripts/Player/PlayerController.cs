using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterBase
{
    public Inventario inventario; 
    // string nombre = "Broth";
    public playerStatsModificables statsMod;
    public PlayerAttackZone playerAttackZone;

    private Animator anim;
    private Rigidbody rb;
    private bool isGrounded;
    private bool inDialogue;
    private bool canMove;
    private bool defending;
    private bool isDead;
    private CharacterBase target;


    public float ActualSpeed;
    public float ActualRotation;

    public PlayerController(string name, string desc, CharacterType type) : base(name, desc, type)
    {
    }

    public bool InDialogue { get { return inDialogue; } set { inDialogue = value; } }
    public bool CanMove { get { return canMove; } set { canMove = value; } }

    public struct playerStatsModificables
    {
        public float vidaCAPModi;
        public float defensaModi;
        public float ataqueModi;
		public float destrecaModi;
		public float manaCAPModi;
		public float StaminaCAPModi;
		public float AlturaCAPModi;
        public float armaduraCAPModi;
        public float speedModi;
    }

	public float VidaCAPTot {get {return characterStats.vidaCAP + statsMod.vidaCAPModi;}}
	public float VidaTot {get {return characterStats.vida;}}
	public float DefensaTot {get {return characterStats.defensa + statsMod.defensaModi;}}
	public float AtaqueTot {get {return characterStats.ataque + statsMod.ataqueModi;}}
	public float DestrezaTot {get {return characterStats.destreza + statsMod.destrecaModi;}}
	public float ManaTot {get {return characterStats.manaCAP + statsMod.manaCAPModi;}}
	public float StaminaTot {get {return characterStats.stamina;}}
	public float ManaCAPTot {get {return characterStats.mana;}}
	public float StaminaCAPTot {get {return characterStats.staminaCAP + statsMod.StaminaCAPModi;}}
    public float SpeedTot { get { return characterStats.speed + statsMod.speedModi; } }
	public float XPTot {get {return characterStats.xp;}}
	public float LevelTot {get {return characterStats.level;}}

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        canAttack = true;
        canMove = true;
    }

    private void Update()
    {
        if (isDead) return;

        if (!inDialogue)
        {
            //Movimiento
            ActualSpeed = Input.GetAxis("Vertical") * SpeedTot;

            if(canAttack && isGrounded && Input.GetMouseButtonDown(0))
            {
                Attack();
                StopDefending();
            }

            if(canAttack && isGrounded)
            {
                if (Input.GetMouseButtonDown(1))
                    Defend();

                if (Input.GetMouseButtonUp(1))
                    StopDefending();
            }

            if (canMove)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    ActualSpeed *= 2f;
                }

                transform.position += transform.forward * ActualSpeed * Time.deltaTime;

                ActualRotation = Input.GetAxis("Horizontal") * SpeedTot;

                transform.Rotate(Vector3.up * ActualRotation);

                if (isGrounded && Input.GetKeyDown(KeyCode.Space))
                {
                    anim.SetTrigger("Jump");
                    rb.AddForce(Vector3.up * 400);
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space)) DialogueManager.Instance.NextSentence();
        }

        anim.SetFloat("Speed", Mathf.Abs(ActualSpeed));
        anim.SetBool("IsGrounded", isGrounded);
        anim.SetBool("IsDefending", defending);

        ActualSpeed = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }

    public void Attack()
    {   
        anim.SetTrigger("Attack");
        for (int i = 0; i < playerAttackZone.EnemyList.Count; i++)
        {
            playerAttackZone.EnemyList[i].TakeDamage(AtaqueTot);
        }

        canAttack = false;
        Invoke("AllowAttack", 10 / DestrezaTot);
    }

    public void Defend()
    {
        if (!defending) anim.SetTrigger("Defend");
        defending = true;
    }

    public void StopDefending()
    {
        defending = false;
    }

    public override void TakeDamage(float damage, EnemyController damager = null)
    {
        if (isDead || (defending && playerAttackZone.EnemyList.Contains(damager)))
            return;

        anim.SetTrigger("TakeDamage");
        base.TakeDamage(damage, damager);
    }

    protected override void OnDeath()
    {
        isDead = true;
        anim.SetBool("Dead", isDead);
        anim.SetTrigger("Die");
        //base.OnDeath();
    }
}
