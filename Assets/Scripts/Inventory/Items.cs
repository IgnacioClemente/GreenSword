using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items {

    public string _name;
    public string desc;
    public Stats itemStats;
    public int cantidad;

    public struct Stats
    {
        public float defensa;
        public float ataque;
        public float altura;
        public float vidaCap;
        public float tiempo;
        public float armadura;
    }

    public virtual void Use(PlayerController p_player)
    {

    }

    public virtual void Throw()
    {

    }
}
