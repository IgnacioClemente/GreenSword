using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour {
    
    public string _name;
    public string desc;
    public Objetivo obj;
    public Reward reward;

    public Stats Queststats;

    public struct Stats
    {
        public float sidequest;
        public float nextquest;
    }
}
