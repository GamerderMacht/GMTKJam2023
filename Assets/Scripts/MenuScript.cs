using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;

    private void Awake()
    {
        Debug.Log(GameManager.Instance);
        startButton.onClick.AddListener(() => GameManager.Instance.HandleStartGame());
        exitButton.onClick.AddListener(() => GameManager.Instance.HandleExit());
    }
}
