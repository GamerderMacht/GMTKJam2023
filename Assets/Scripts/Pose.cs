using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pose : MonoBehaviour
{
    public PosePart keyboardPose;
    public PosePart mousePose;
    public TMP_Text scoreText;

    public bool isHit;
    public int score;
    public bool alive;
    public float decay_speed;
    float decay_cd;
    HealthManager healthManager;
    int rotation;

    public void Init(Vector2 constraints, float _decay_speed)
    {
        float kx = Random.Range(-constraints.x, constraints.x);
        float kz = Random.Range(-constraints.y, constraints.y);
        float mx = Random.Range(-constraints.x, constraints.x);
        float mz = Random.Range(-constraints.y, constraints.y);

        mousePose.transform.position = new Vector3(mx, 0f, mz);
        keyboardPose.transform.position = new Vector3(kx, 0f, kz);

        score = 100;
        decay_speed = _decay_speed > 0f ? _decay_speed : 0.01f;
        decay_cd = 1f / decay_speed;
        rotation = Random.Range(-1, 2);
        keyboardPose.SetRotation(rotation);

        alive = true;
    }

    private void Update()
    {
        isHit = false;
        if (alive && keyboardPose.isHit && mousePose.isHit)
        {
            isHit = true;
            Debug.Log(EventBus.Instance);
            EventBus.Instance.OnPoseHit.Invoke();
        }

        if (alive == false) transform.localScale.Set(0f, 0f, 0f);


        DecayTick(Time.deltaTime);
    }

    void DecayTick(float deltaTime)
    {
        decay_cd -= deltaTime;
        if (decay_cd < 0f)
        {
            DecreaseScore();
            decay_cd = 1f / decay_speed;
        }
    }

    void DecreaseScore()
    {

        score--;
        scoreText.text = score.ToString();
        if (score < 0)
        {
            EventBus.Instance.OnFail.Invoke();
            healthManager = GameObject.FindObjectOfType<HealthManager>();
            healthManager.LoseHealth();
            
        }

    }
}
