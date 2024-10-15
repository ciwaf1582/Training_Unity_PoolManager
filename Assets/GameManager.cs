using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform[] endPoint;
    public PoolManager poolManager;


    private void Awake()
    {
        instance = this;
    }
}

