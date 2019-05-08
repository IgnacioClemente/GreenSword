using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pasive : Items
{
    bool activate;
    float contador;
    public PlayerController _player; 
    public override void Use(PlayerController p_player)
    {
        activate = true;
        p_player.statsMod.vidaCAPModi += itemStats.vidaCap;
        p_player.statsMod.ataqueModi += itemStats.ataque;
        p_player.statsMod.defensaModi += itemStats.defensa;
        p_player.statsMod.AlturaCAPModi += itemStats.altura;
        _player.statsMod.armaduraCAPModi += itemStats.armadura;
        _player = p_player;
    }

    public void Finish(PlayerController p_player)
    {
        contador = 0;
        activate = false;
        p_player.statsMod.vidaCAPModi -= itemStats.vidaCap;
        p_player.statsMod.ataqueModi -= itemStats.ataque;
        p_player.statsMod.defensaModi -= itemStats.defensa;
        p_player.statsMod.AlturaCAPModi -= itemStats.altura;
        _player.statsMod.armaduraCAPModi += itemStats.armadura;
    }
    public override void Throw()
    {
        cantidad -= 1;
    }

    void Update()
    {
        if (activate)
        {
            contador += Time.deltaTime;
            if (contador > itemStats.tiempo)
            {
                Finish(_player);
            }
        }
    }
}
