using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{
    [HideInInspector]
    public UnityEvent OnGameStart = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnGameEnd = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnStageSuccess = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnStageFail = new UnityEvent();

    private bool isGameStarted;
    public bool IsGameStarted { get { return isGameStarted; } set { isGameStarted = value; } }

    public void StartGame()
    {
        if (isGameStarted)
            return;

        isGameStarted = true;
        OnGameStart.Invoke();
    }

    public void EndGame()
    {
        if (!isGameStarted)
            return;
        isGameStarted = false;
        OnGameEnd.Invoke();
    }
    public void CompeleteStage(bool value)
    {
        if (!LevelManager.Instance.IsLevelStarted)
            return;

        if (value)
            OnStageSuccess.Invoke();
        else OnStageFail.Invoke();
    }
}
