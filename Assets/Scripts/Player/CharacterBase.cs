using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    public string _name;
    public string desc;
    public CharacterType type;
	public Stats playerStats;
    //characterType type = characterType.Guerrero;
    public CharacterBase (string name, string desc, CharacterType type)
    {
        _name = name;
        this.desc = desc;
        this.type = type;
    }

	public void AddBaseInfo(CharacterBase _baseInfo)
	{
		_name = _baseInfo._name;
		desc = _baseInfo.desc;
		type = _baseInfo.type;
		playerStats = _baseInfo.playerStats;
	}
}

public enum CharacterType
{
    Guerrero, Heroe, Arquero, Protectores, BOSS, ERROR
}

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
    public float rotation;
}