using UnityEngine;
using System.Collections;

public class Personaje {

    //ESTO YA LO TIENEN HECHO, EL HIJO DE PLAYER BASE QUE HICIMOS EN LA PRIMERA CLASE
    public string name;
    public string descrip;
    public Stats playerStats;

    public struct Stats
    {
        public float ataque;
        public float defensa;
    }
}
