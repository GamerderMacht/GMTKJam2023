using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnManager : Constants
{

    //Spawn das Feld
    public GameObject spawnKeyboardSilhouette;
    public GameObject spawnMouseSilhouette;
    public Pose PosePrefab;

    Pose currentPose = null;

    [SerializeField] float timeToSpawn = 1f;
    [SerializeField] float spawnCooldown = 3f;

    public bool isSpawned;
    public float start_game_speed;
    public float multiply_game_speed;
    public float game_speed;

    public Vector2 constraints;
    [SerializeField] AudioManager audioManager;
    

    void Start()
    {
        constraints = GameObject.FindObjectOfType<Constants>().bounds;
        EventBus.Instance.OnPoseHit.AddListener(() =>
        {
            audioManager.PlayPoseHitSound();
            currentPose.PlayVFX(true);
            PoseSuccess();
            TryDestroyPose();
        });
        EventBus.Instance.OnFail.AddListener(() =>
        {
            audioManager.PlayPoseFailSound();
            currentPose.PlayVFX(false);
            TryDestroyPose();
        });

        EventBus.Instance.OnGameOver.AddListener(() => TryDestroyPose());
        EventBus.Instance.OnReset.AddListener(() => TryDestroyPose());
        EventBus.Instance.OnReset.AddListener(() => Reset());
        EventBus.Instance.OnSoftReset.AddListener(()=> TryDestroyPose());

        Reset();
    }

    void Reset(){

        game_speed = start_game_speed;
    }

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space)) TrySpawnPose();

        // if (currentPose != null) return;
        // spawnCooldown -= Time.deltaTime;
        // if (spawnCooldown <= 0)
        // {
        //     // SpawnKeyboard();
        //     // SpawnMouse();
        //     // SpawnPose();
        //     spawnCooldown = timeToSpawn;
        // }
        if (GameManager.Instance.gameState == GameState.GAME)
            TrySpawnPose();
    }

    void TrySpawnPose()
    {
        if (currentPose != null) return;
        Pose newPose = Instantiate(PosePrefab, Vector3.zero, Quaternion.identity, this.transform);
        newPose.Init(constraints, game_speed);
        currentPose = newPose;
        audioManager.PlaySpawnSound();
    }

    void PoseSuccess()
    {
        EventBus.Instance.OnScore.Invoke(currentPose.score);
        game_speed *= multiply_game_speed;
    }

    void TryDestroyPose()
    {
        // if (hit)
        // {
        // 
        // }
        try{

            currentPose.alive = false;
            Destroy(currentPose.gameObject);
        }
        catch{

        }
    }

    void SpawnKeyboard()
    {
        float x = Random.Range(-constraints.x, constraints.x);
        float z = Random.Range(-constraints.y, constraints.y);

        Instantiate(spawnKeyboardSilhouette, new Vector3(x, 0, z),
        Quaternion.Euler(-90, Random.Range(-30.0f, 30.0f), 180), this.transform);
    }

    void SpawnMouse()
    {
        float x = Random.Range(-constraints.x, constraints.x);
        float z = Random.Range(-constraints.y, constraints.y);

        Instantiate(spawnMouseSilhouette, new Vector3(x, 0, z), Quaternion.Euler(0, 90, 0), this.transform);
    }

    
}
