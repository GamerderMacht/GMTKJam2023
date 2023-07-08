using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventBus : MonoBehaviour
{
    public static EventBus Instance;

    public UnityEvent<int> OnScore = new UnityEvent<int>();
    public UnityEvent OnPoseHit = new UnityEvent();
    public UnityEvent OnFail = new UnityEvent();

    public UnityEvent OnReset = new UnityEvent();
    public UnityEvent OnGameOver = new UnityEvent();
    
    private void Awake()
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
}
