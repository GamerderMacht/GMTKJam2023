using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public enum GameState { MENU, PAUSED, GAME }

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState gameState /*{ get; private set; }*/ = GameState.MENU;

    public string menuSceneName;
    public string gameSceneName;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        SceneManager.sceneLoaded += (Scene scene, LoadSceneMode mode) => OnScenesChanged();
        SceneManager.sceneUnloaded += (Scene scene) => OnScenesChanged();

        SceneManager.LoadScene(gameSceneName, LoadSceneMode.Single);
        SceneManager.LoadScene(menuSceneName, LoadSceneMode.Additive);

        Cursor.visible = false;
    }

    public void HandleExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void HandleStartGame()
    {
        SceneManager.UnloadSceneAsync(menuSceneName);
        gameState = GameState.GAME;
        EventBus.Instance.OnReset.Invoke();
    }

    public void HandleToMenu()
    {
        SceneManager.LoadScene(menuSceneName, LoadSceneMode.Additive);
        gameState = GameState.MENU;
    }

    public void OnScenesChanged()
    {   
        // Debug.Log("onScenesChanged");
        // bool menu = false;
        // for(int i = 0; i < SceneManager.sceneCount; i++){
        //     Debug.Log(SceneManager.GetSceneAt(i).name);
        //     if(SceneManager.GetSceneAt(i).name == menuSceneName) menu = true;
        // }
        // gameState = menu ? GameState.MENU : GameState.GAME; //TODO: Paused
    }



    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            switch (gameState)
            {
                case GameState.MENU: HandleExit(); break;
                case GameState.GAME: HandleToMenu(); break;
            }
        }
    }


    
}
