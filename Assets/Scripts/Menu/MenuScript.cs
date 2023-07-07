using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;
    public Button3D startButton3D;

    private void Awake()
    {
        startButton.onClick.AddListener(() => GameManager.Instance.HandleStartGame());
        exitButton.onClick.AddListener(() => GameManager.Instance.HandleExit());
        startButton3D.onActivate.AddListener(() => GameManager.Instance.HandleStartGame());
    }
}
