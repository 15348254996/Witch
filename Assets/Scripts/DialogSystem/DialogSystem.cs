using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [Header("对话系统组件")]
    public Text DialogText;//对话框
    public TextAsset DialogResources;//对话资源
    public Image People1;//对话第一人
    public Image People2;//对话第二人
    public GameObject Panel;
    List<string> Textlist = new List<string>();
    private bool isget = false;
    private static int index = 0;
    void loadTextAsset(TextAsset textres)
    {
        DialogResources = textres;
    }
    public void showtext(TextAsset textres, Text dialogtext)
    {
        loadTextAsset(textres);
        GetListfromFile();
        if (Input.GetKeyDown(KeyCode.Space) && index == Textlist.Count)
        {
            index = 0;
            Panel.SetActive(false);
            BaseCharacter.status = BaseCharacter.statuses.normal;
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dialogtext.text = Textlist[index];
            index++;
            Debug.Log(Textlist.Count);
            Debug.Log(index);
        }
    }

    void GetListfromFile()
    {
        if (isget == false)
        {
            if (DialogResources != null)
            {
                var alltext = DialogResources.text.Split('\n');
                foreach (var everytext in alltext)
                {
                    Textlist.Add(everytext);
                }
            }
            isget = true;
        }
    }
}
