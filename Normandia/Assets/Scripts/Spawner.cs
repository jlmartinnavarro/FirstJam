using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public Transform enemyPrefabNormal;
    public Transform enemyPrefabSmall;
    public Transform enemyPrefabBig;
    public Transform[] enemyPrefab;
    private int waveNumber = 5;
    float waitBetweeenEnemies = 1f;

    public float timeBetweenWaves = 10f;
    private float countdown = 5f;

    public GameObject Victoria;
    // Use this for initialization
    void Start () {
        countdown = 0f;
        enemyPrefab = new Transform[3];
        enemyPrefab[0] = enemyPrefabNormal;
        enemyPrefab[1] = enemyPrefabSmall;
        enemyPrefab[2] = enemyPrefabBig;
	}
	
	// Update is called once per frame
	void Update () {
        if (countdown <= 0f)
        {
            if (waveNumber < 10)
            {
                StartCoroutine(spawnWave());
                countdown = timeBetweenWaves;
            }
            else
            {
                if (GameObject.FindGameObjectsWithTag(SceneController.enemyTag).Length == 0 && GameObject.FindGameObjectsWithTag("Breakable").Length > 0)
                {
                    if (GameObject.FindGameObjectWithTag("Breakable").GetComponent<Breakable>().health > 0)
                    {
                        Victoria.SetActive(true);
                    }
                }
            }
        }
        countdown -= Time.deltaTime;
    }

    IEnumerator spawnWave()
    {
        //TODO parametros de la wave desde array
        for (int i = 0; i < waveNumber; i++)
        {
            Debug.Log("i " + i + " % " + enemyPrefab.Length + " " + i % enemyPrefab.Length);
            //TODO pasar ID de enemigo, espera entre enemigos desde array de información
            SpawnEnemy(i % enemyPrefab.Length);
            yield return new WaitForSeconds(waitBetweeenEnemies);
        }
        waveNumber++;

        //numOfEnemies = WaveSpawner[waveNumber].count;
        //numOfEnemies = waveNumber * waveNumber + 1;
        Debug.Log("Wave goin");
    }

    //TODO pasar ID de enemigo
    void SpawnEnemy(int i)
    {
        Instantiate(enemyPrefab[i], this.gameObject.GetComponent<Transform>().position, this.gameObject.GetComponent<Transform>().rotation);
    }


}
