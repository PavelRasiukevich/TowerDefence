using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region SINGLETON
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public event Action secondMouseButtonClick;

    #region My Spawner
    /*[SerializeField] Transform _spawnPoint;
    [SerializeField] Transform _enemyPrefab;

    public float timeBetweenEnemyInstantiate;
    public float waveCountDown;

    private void Update()
    {
        if (waveCountDown > 0)
        {
            if (timeBetweenEnemyInstantiate <= 0)
            {
                SpawnEnemy();
            }


        }
        else
        {
            timeBetweenEnemyInstantiate = 0;
            waveCountDown = 0;
        }

        timeBetweenEnemyInstantiate -= Time.deltaTime;
        waveCountDown -= Time.deltaTime;
    }

    private void SpawnEnemy()
    {
        Instantiate(_enemyPrefab, _spawnPoint.position, Quaternion.identity);
        timeBetweenEnemyInstantiate = 2;
    }*/
    #endregion
    public Text timer;

    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countDown = 5f;

    private int waveIndex = 0;

    private void Update()
    {
        if (countDown <= 0)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
        }

        countDown -= Time.deltaTime;

        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);

        timer.text = string.Format("Time to next wave: \n {0:00.00}", countDown);

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            secondMouseButtonClick?.Invoke();
        }
    }

    private IEnumerator SpawnWave()
    {
        waveIndex++;
        PlayerStats.wavesSurvived++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.25f);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }
}
