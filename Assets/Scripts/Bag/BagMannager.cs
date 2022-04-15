using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagMannager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject BagObject;
    public Text text;
    void Start()
    {
        BagObject = gameObject.transform.Find("BagBack").gameObject;
        text = gameObject.transform.Find("Text").gameObject.GetComponent<Text>();
    }


    void Update()
    {
        PanelShow();
    }
    void PanelShow()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (BagObject.activeSelf == true)
            {
                BagObject.SetActive(false);
                text.gameObject.SetActive(false);
            }
            else
            {
                BagObject.SetActive(true);
                text.gameObject.SetActive(true);
            }
        }
    }

}
