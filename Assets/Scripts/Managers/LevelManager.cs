using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class LevelManager : Singleton<LevelManager>
{
    [HideInInspector]
    public UnityEvent OnLevelStart = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnLevelFinish = new UnityEvent();
    [HideInInspector]
    bool isLevelStarted;

    //[HideInInspector]
    public int LevelIndex;
    public bool IsLevelStarted { get { return isLevelStarted; } set { isLevelStarted = value; } }
    private void Start()
    {
        LevelIndex = 1;
        LevelStarted();
    }
    private void OnEnable()
    {
        GameManager.Instance.OnStageSuccess.AddListener(SuccesLevel);
        GameManager.Instance.OnStageFail.AddListener(FailLevel);
        SceneController.Instance.OnSceneLoaded.AddListener(LevelStarted);
    }
    private void OnDisable()
    {
        GameManager.Instance.OnStageSuccess.RemoveListener(SuccesLevel);
        GameManager.Instance.OnStageFail.RemoveListener(FailLevel);
        SceneController.Instance.OnSceneLoaded.RemoveListener(LevelStarted);

    }
    public void LevelStarted()
    {
        isLevelStarted = true;
        OnLevelStart.Invoke();
    }
    public void LevelFinish()
    {
        isLevelStarted = false;
        OnLevelFinish.Invoke();

    }
    private void SuccesLevel()
    {
        LevelFinish();
        SceneController.Instance.UnLoadScene("level" + LevelIndex);
        if (LevelIndex == 2)
            LevelIndex = 0;
        LevelIndex++;
        SceneController.Instance.LoadScene("level" + LevelIndex);
    }
    private void FailLevel()
    {
        LevelFinish();
        SceneController.Instance.RestartLevel("level" + LevelIndex);

    }
}
