using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Constants
{

    //Spawn das Feld
    public GameObject spawnKeyboardSilhouette;
    public GameObject spawnMouseSilhouette;

    [SerializeField] float timeToSpawn = 1f;
    [SerializeField] float spawnCooldown = 3f;


    public Vector2 constraints;

    // Start is called before the first frame update
    void Start()
    {
        constraints = GameObject.FindObjectOfType<Constants>().bounds;
    }

    // Update is called once per frame
    void Update()
    {
        spawnCooldown -= Time.deltaTime;
        if (spawnCooldown <= 0)
        {
            SpawnKeyboard();
            SpawnMouse();
            spawnCooldown = timeToSpawn;
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

        Instantiate(spawnMouseSilhouette, new Vector3(x, 0, z), Quaternion.Euler(0,90,0), this.transform);
    }
}
