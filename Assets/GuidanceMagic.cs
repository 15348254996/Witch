using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidanceMagic : MonoBehaviour
{
    public GameObject Charactor;
    public GameManager gameManager;
    private void Start()
    {
        Charactor = GameObject.Find("Character");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        if (other == Charactor.GetComponent<Collider2D>())
        {
            GameManager.SceneChange("Finish");
        }
    }
}
