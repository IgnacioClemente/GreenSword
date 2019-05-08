using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour {

    public string _name;
    public string desc;
    public characterType type;
	public Stats playerStats;
    //characterType type = characterType.Guerrero;

    //Vector3 posicion;
    //animaciones
   //weapon
  //state

   public struct Stats
	{
		public float vida;
		public float vidaCAP;
        public float defensa;
        public float ataque;
        public float level;
		public float destreza;
		public float mana;
		public float stamina;
		public float manaCAP;
		public float staminaCAP;
        public float xp;
        public float speed;
    }

    public enum characterType
    {
        Guerrero, Heroe, Arquero, Protectores, BOSS, ERROR
    }

	public void AddBaseInfo(CharacterBase _baseInfo)
	{
		_name = _baseInfo._name;
		desc = _baseInfo.desc;
		type = _baseInfo.type;
		playerStats = _baseInfo.playerStats;
	}
}
