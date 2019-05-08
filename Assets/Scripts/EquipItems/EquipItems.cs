using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItems : Items
{
    public override void Use(PlayerController _player)
    {
        _player.statsMod.vidaCAPModi += itemStats.vidaCap;
        _player.statsMod.ataqueModi += itemStats.ataque;
        _player.statsMod.defensaModi += itemStats.defensa;
        _player.statsMod.AlturaCAPModi += itemStats.altura;
        _player.statsMod.armaduraCAPModi += itemStats.armadura;
    }
}
