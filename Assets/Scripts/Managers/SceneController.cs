using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class SceneController : Singleton<SceneController>
{
    [HideInInspector]
    public UnityEvent OnSceneLoaded = new UnityEvent();

    public void LoadScene(string level)
    {
        SceneManager.LoadScene(level);
        OnSceneLoaded.Invoke();
    }
    public void RestartLevel(string level)
    {
        SceneManager.LoadScene(level);
        OnSceneLoaded.Invoke();

    }
    public void LoadNextLevel(string level)
    {
        SceneManager.LoadScene(level);
        OnSceneLoaded.Invoke();
    }
    public void LoadPreviousLevel(string level)
    {
        SceneManager.LoadScene(level);
        OnSceneLoaded.Invoke();

    }
    public void UnLoadScene(string level)
    {
        SceneManager.UnloadSceneAsync(level);
    }
}
