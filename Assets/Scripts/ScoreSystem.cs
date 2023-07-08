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
    }

    // void Start()
    // {
    //     canvasScript = GameObject.FindGameObjectWithTag("Canvas").GetComponent<CanvasScript>();
    // }

    void Update()
    {
        // Debug.Log(EventBus.Instance.OnScore);
        if (Input.GetKeyDown(KeyCode.M))
        {
            EventBus.Instance.OnScore.Invoke(10);
        }
    }

    public void AddScore(int points)
    {
        score += points;

        // canvasScript.UpdateCanvas(score);
        // canvasScript.PlayCanvasAnimation();

    }
}
