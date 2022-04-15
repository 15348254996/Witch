using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    public GameObject loadScreen;
    public Slider slider;
    public void LoadNextLevel()
    {
        StartCoroutine(Loadlevel());
    }
    IEnumerator Loadlevel()
    {
        loadScreen.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        operation.allowSceneActivation = true;
        while (!operation.isDone)
        {
            slider.value = operation.progress;
            yield return null;
        }
    }
}
