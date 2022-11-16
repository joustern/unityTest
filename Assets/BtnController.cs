using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnController : MonoBehaviour
{
    public void ReStart()
    {
        SceneManager.LoadScene(0);
        SceneManager.sceneLoaded += OnSceneLoaded;
        Time.timeScale = 1;
    }
    public void gameStart()
    {
        Time.timeScale = 1;
        Canvas[] cv = FindObjectsOfType<Canvas>();
        foreach(Canvas temp in cv)
        {
            if (temp.name == "StartCV")
            {
                Destroy(temp.gameObject);
            }
        }
        ObjController.gStart = true;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        gameStart();
    }
}
