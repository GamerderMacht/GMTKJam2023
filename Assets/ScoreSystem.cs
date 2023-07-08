using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScoreSystem : MonoBehaviour
{

    

    public int score = 0;

    CanvasScript canvasScript;
    // Start is called before the first frame update
    void Start()
    {
        canvasScript = GameObject.FindGameObjectWithTag("Canvas").GetComponent<CanvasScript>();
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
        
        canvasScript.UpdateCanvas(score);
        canvasScript.PlayCanvasAnimation();

    }
}
