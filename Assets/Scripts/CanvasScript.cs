using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    ScoreSystem scoreSystem;

    private void OnEnable()
    {
        scoreSystem = GameObject.FindObjectOfType<ScoreSystem>();
        EventBus.Instance.OnScore.AddListener((x) => UpdateCanvas());

        UpdateCanvas();
    }

    public void UpdateCanvas()
    {
        // Debug.Log("scored");
        scoreText.text = "Score: " + scoreSystem.score;
    }


    public void PlayCanvasAnimation()
    {

    }
}
