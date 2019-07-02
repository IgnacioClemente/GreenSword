using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController player;

    public static GameManager Instance { get; private set; }

    public PlayerController Player { get { return player; } }

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        Instance = this;
    }
}
