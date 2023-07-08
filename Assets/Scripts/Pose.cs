using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pose : MonoBehaviour
{
    public PosePart keyboardPose;
    public PosePart mousePose;

    public bool isHit;
    public int score;
    public bool alive;

    public void Init(Vector2 constraints)
    {
        float kx = Random.Range(-constraints.x, constraints.x);
        float kz = Random.Range(-constraints.y, constraints.y);
        float mx = Random.Range(-constraints.x, constraints.x);
        float mz = Random.Range(-constraints.y, constraints.y);

        mousePose.transform.position = new Vector3(mx, 0f, mz);

        keyboardPose.transform.position = new Vector3(kx, 0f, kz);

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

        if(alive == false) transform.localScale.Set(0f,0f,0f);
    }
}
