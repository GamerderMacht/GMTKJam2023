using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{

    TextMeshProUGUI scoreText;

    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            AddScore(100);
        }
    }




    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
        


    }

    void PlayScoreAnimation()
    {

    }
}
