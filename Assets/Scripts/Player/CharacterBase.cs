using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    public string _name;
    public string desc;
    public CharacterType type;
	public Stats characterStats;

    protected bool canAttack = true;
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
		characterStats = _baseInfo.characterStats;
	}

    public virtual void TakeDamage(float damage, EnemyController damager = null)
    {
        characterStats.vida -= (damage - characterStats.defensa);
        Debug.Log(gameObject.name + " tomo " + (damage - characterStats.defensa) + " de daño, le quedan " + characterStats.vida + " de vida sobre " + characterStats.vidaCAP);
        if (characterStats.vida <= 0) OnDeath();
    }

    protected virtual void OnDeath()
    {
        Destroy(gameObject);
    }

    protected virtual void AllowAttack()
    {
        canAttack = true;
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