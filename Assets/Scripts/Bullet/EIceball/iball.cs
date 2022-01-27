using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iball : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CtrlCharacter>().status != BaseCharacter.statuses.die &&
        other.GetComponent<CtrlCharacter>().status != BaseCharacter.statuses.frozen)
        {
            Destroy(this.transform.parent.gameObject);
            other.GetComponent<CtrlCharacter>().Takedamage(25);
            other.GetComponent<CtrlCharacter>().status = BaseCharacter.statuses.frozen;
        }
    }
}
