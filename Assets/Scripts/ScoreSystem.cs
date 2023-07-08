using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScoreSystem : MonoBehaviour
{
    public int score = 0;

    // CanvasScript canvasScript;

    private void OnEnable()
    {
        EventBus.Instance.OnScore.AddListener((amount) => AddScore(amount));
        EventBus.Instance.OnReset.AddListener(() => score = 0);
    }

    // void Start()
    // {
    //     canvasScript = GameObject.FindGameObjectWithTag("Canvas").GetComponent<CanvasScript>();
    // }

    void Update()
    {
        
    }

    public void AddScore(int points)
    {
        score += points;

        // canvasScript.UpdateCanvas(score);
        // canvasScript.PlayCanvasAnimation();

    }
}
