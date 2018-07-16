using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public Transform enemyPrefab;
    private int waveNumber = 0;

    public float timeBetweenWaves = 5f;
    private float countdown = 10f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (countdown <= 0f)
        {
            StartCoroutine(spawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
    }

    IEnumerator spawnWave()
    {
        //TODO parametros de la wave desde array
        for (int i = 0; i < waveNumber; i++)
        {
            //TODO pasar ID de enemigo, espera entre enemigos desde array de información
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        waveNumber++;

        //numOfEnemies = WaveSpawner[waveNumber].count;
        //numOfEnemies = waveNumber * waveNumber + 1;
        Debug.Log("Wave goin");
    }

    //TODO pasar ID de enemigo
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, this.gameObject.GetComponent<Transform>().position, this.gameObject.GetComponent<Transform>().rotation);
    }


}
