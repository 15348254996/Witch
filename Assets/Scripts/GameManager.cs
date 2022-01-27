using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameManager() { }
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }
}
