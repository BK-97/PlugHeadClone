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
        SceneManager.LoadScene(level, LoadSceneMode.Additive);
        OnSceneLoaded.Invoke();
    }
    public void RestartLevel(string level)
    {
        StartCoroutine(WaitSceneOpenCO(level));
    }
    public void LoadNextLevel(string level)
    {
        SceneManager.LoadScene(level, LoadSceneMode.Additive);
        OnSceneLoaded.Invoke();
    }
    public void UnLoadScene(string level)
    {
        SceneManager.UnloadSceneAsync(level);
    }
    IEnumerator WaitSceneOpenCO(string level)
    {
        SceneManager.UnloadSceneAsync(level);
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(level, LoadSceneMode.Additive);
        OnSceneLoaded.Invoke();

    }
}
