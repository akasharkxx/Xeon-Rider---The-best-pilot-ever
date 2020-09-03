using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public enum GameState
    {
        PREGAME,
        RUNNING,
        PAUSED
    }

    public GameState _currentGameState;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        _currentGameState = GameState.PREGAME;
    }

    private void LoadNewScene(string scene)
    {
        SceneManager.LoadSceneAsync(scene);
    }


}
