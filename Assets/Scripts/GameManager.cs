using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public enum GameState { MENU, GAME }

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    public GameState gameState /*{ get; private set; }*/ = GameState.MENU;

    public string menuSceneName;
    public string gameSceneName;

    private void OnEnable()
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
    }

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        Instance = null;
    }

    public void HandleExit()
    {
        Application.Quit();
    }

    public void HandleStartGame()
    {
        SceneManager.LoadScene(gameSceneName, LoadSceneMode.Single);
    }

    public void HandleToMenu()
    {
        SceneManager.LoadScene(menuSceneName, LoadSceneMode.Single);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
       if(scene.name == menuSceneName) gameState = GameState.MENU;
       else if(scene.name == gameSceneName) gameState = GameState.GAME;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            switch(gameState){
                case GameState.MENU: HandleExit(); break;
                case GameState.GAME: HandleToMenu(); break;
            }
        }
    }
}
