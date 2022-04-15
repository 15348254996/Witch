using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iball : MonoBehaviour
{
    GameManager gameManager;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (CtrlCharacter.status != BaseCharacter.statuses.die &&
        CtrlCharacter.status != BaseCharacter.statuses.frozen)
        {
            //ssCtrlCharacter.status = BaseCharacter.statuses.frozen;
            other.GetComponent<CtrlCharacter>().Takedamage(25);
            //gameManager.CountdowntoNormal(other);
            Destroy(this.transform.parent.gameObject);
        }
    }
}
