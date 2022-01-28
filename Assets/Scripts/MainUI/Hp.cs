using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp : MonoBehaviour
{
    public GameObject character;
    private int HP;
    private void Start()
    {
        character = GameObject.Find("Character");
    }
    private void Update()
    {
        HP = character.GetComponent<CtrlCharacter>().HP;
        float proportion = (float)HP / character.GetComponent<CtrlCharacter>().MaxHP;
        this.GetComponent<Image>().fillAmount = proportion;
    }

}
