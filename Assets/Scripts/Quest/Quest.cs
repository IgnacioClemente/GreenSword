using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest {
    
    public string _name;
    public string desc;
    public Objetivo obj;
    public Reward reward;
    public int actualAmount;

    public Stats Queststats;

    public struct Stats
    {
        public string sidequest;
        public string nextquest;
    }
}
