using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterBase
{
   public Inventario inventario; 
   // string nombre = "Broth";
   public playerStatsModificables statsMod;

    private Animator anim;
    private Rigidbody rb;

    public float ActualSpeed;

    public float ActualRotation;


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
        public float rotateModi;
    }

	public float VidaCAPTot {get {return playerStats.vidaCAP + statsMod.vidaCAPModi;}}
	public float VidaTot {get {return playerStats.vida;}}
	public float DefensaTot {get {return playerStats.defensa + statsMod.defensaModi;}}
	public float AtaqueTot {get {return playerStats.ataque + statsMod.ataqueModi;}}
	public float DestrezaTot {get {return playerStats.destreza + statsMod.destrecaModi;}}
	public float ManaTot {get {return playerStats.manaCAP + statsMod.manaCAPModi;}}
	public float StaminaTot {get {return playerStats.stamina;}}
	public float ManaCAPTot {get {return playerStats.mana;}}
	public float StaminaCAPTot {get {return playerStats.staminaCAP + statsMod.StaminaCAPModi;}}
    public float SpeedTot { get { return playerStats.speed + statsMod.speedModi; } }
    public float rotateTot { get { return playerStats.rotation + statsMod.rotateModi; } }
	public float XPTot {get {return playerStats.xp;}}
	public float LevelTot {get {return playerStats.level;}}

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ActualSpeed = Input.GetAxis("Vertical") * SpeedTot;

        if(Input.GetKey(KeyCode.LeftShift))
        {
            ActualSpeed *= 2f;
        }
        
        transform.position += transform.forward *  ActualSpeed * Time.deltaTime;

        ActualRotation = Input.GetAxis("Horizontal") * SpeedTot;

        transform.Rotate(Vector3.up * ActualRotation);

        if (Input.GetKeyDown(KeyCode.Space)) rb.AddForce(Vector3.up * 400); 

        anim.SetFloat("Speed", Mathf.Abs(ActualSpeed));
    }
}
