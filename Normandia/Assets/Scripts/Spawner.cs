using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public Transform enemyPrefab;
    private int waveNumber = 2;

    public float timeBetweenWaves = 5f;
    private float countdown = 5f;

    public GameObject Victoria;
    // Use this for initialization
    void Start () {
        countdown = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (countdown <= 0f)
        {
            if (waveNumber < 5)
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
