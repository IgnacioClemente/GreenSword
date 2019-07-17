using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemyController : EnemyController
{
    [SerializeField] ProyectilController proyectile;
    [SerializeField] Transform shotSpawn;
    public RangeEnemyController(string name, string desc, CharacterType type) : base(name, desc, type)
    {
    }

    protected override void Attack()
    {
        if (proyectile != null)
        {
            anim.SetTrigger("Attack");
            var proyectileAux = Instantiate(proyectile, transform.position, proyectile.transform.rotation);
            proyectileAux.SetDirection((player.transform.position - transform.position).normalized);
            canAttack = false;
            Invoke("AllowAttack", 10 / characterStats.destreza);
        }
    }
}

