using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ST_LoadPlayLevel : State
{
    AsyncOperation _asyncOperation;
    public override void EnterState()
    {
        Debug.Log("Entered GameManager ST_LoadPlayLevel");

        if(SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(0))
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(0));
        _asyncOperation = SceneManager.LoadSceneAsync(n, LoadSceneMode.Additive);
        _asyncOperation.completed += LevelLoaded;
    }
    public override void UpdateState()
    {

    }
    public override void ExitState()
    {
        Debug.Log("Exited GameManager ST_LoadPlayLevel");
    }

    void LevelLoaded(AsyncOperation _asyncOperation)
    {
        _asyncOperation.completed -= LevelLoaded;
        EventManager.Instance.LevelLoaded();
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(n));

        GameManager.Instance.ChangeState<ST_GamePlay>();
    }
}
