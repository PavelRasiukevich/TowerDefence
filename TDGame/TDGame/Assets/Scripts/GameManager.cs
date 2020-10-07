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

    public GameObject youWinUI;
    public int EnemiesAlive = 0;

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

    public Wave[] waves;
    Wave wave;

    public Transform spawnPoint;

    public float timeBetweenWaves;
    private float countDown = 5f;

    private int waveIndex = 0;

    public bool waveInAction;

    public bool isSkiped;

    private void Start()
    {
        countDown = timeBetweenWaves;
        waveInAction = true;
        isSkiped = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            secondMouseButtonClick?.Invoke();
        }

        if (EnemiesAlive > 0)
        {
            return;
        }

        


        if (waveInAction)
        {
            if (countDown <= 0)
            {
                StartCoroutine(SpawnWave());
                countDown = timeBetweenWaves;
                return;
            }

            countDown -= Time.deltaTime;

            countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);

            timer.text = string.Format("Next wave in: {0:00.00}", countDown);
        }

        if (EnemiesAlive == 0 && waveIndex == waves.Length)
        {
            GameController.GameIsOver = true;
            youWinUI.SetActive(!waveInAction);
        }
        else
        {
            return;
        }


    }

    private IEnumerator SpawnWave()
    {
        wave = waves[waveIndex];
        EnemiesAlive = wave.count;
        PlayerStats.wavesSurvived = PlayerStats.wavesSurvived - 1;

        

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemyPrefab);

            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;

        if (waveIndex == waves.Length)
        {
            waveInAction = false;
        }
    }

    private void SpawnEnemy(GameObject wave)
    {

        //waves[waveIndex].enemyPrefab;

        Instantiate(wave, spawnPoint.position, Quaternion.identity);

    }

    public void SkipWaveTiner()
    {
        if (isSkiped == false)
        {
            countDown = 0;
            timer.text = string.Format("Next wave in: {0:00.00}", countDown);
            isSkiped = true;
        }

    }
}
