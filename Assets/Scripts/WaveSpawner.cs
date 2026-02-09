using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive;
    public static int EnemiesKilled;
    public Wave[] waves;
    public Transform spawnPoint;
    public static float TimeBetweenWaves;
    private static float _countdown;
    public Text waveCountdownText;
    private static int _waveIndex;
    public GameManager gameManager;
    
    private static bool _active;
    
    void Awake()
    {
        EnemiesAlive = 0;
        EnemiesKilled = 0;
        _waveIndex = 0;
        _active = false;
        Time.timeScale = 0f;
        TimeBetweenWaves = 5.5f;
        _countdown = TimeBetweenWaves;
    }

    void Update()
    {
        if (GameManager.GameIsOver)
        {
            return;
        }

        if (_active)
        {
            if (EnemiesAlive > 0)
            {
                return;
            }
            
            if (_waveIndex >= 10)
            {
                gameManager.WinGame();
                this.enabled = false;
            }
            
            if (_countdown <= 0f)
            {
                StartCoroutine(SpawnWave());
                _countdown = TimeBetweenWaves;
                return;
            }

            _countdown -= Time.deltaTime;

            _countdown = Mathf.Clamp(_countdown, 0f, Mathf.Infinity);

            waveCountdownText.text = $"{_countdown:00.00}";
        }
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;
        
        Wave wave;
        
        if (_waveIndex >= waves.Length)
        {
            wave = waves[Random.Range(0, waves.Length - 1)];
            wave.count++;
        }
        else
        {
            wave = waves[_waveIndex];
        }
        
        EnemiesAlive =  wave.count;
        EnemiesKilled = 0;
        
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        
        _waveIndex++;
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
    
    public static void SetActive()
    {
        _active = true;
        Time.timeScale = 1f;
    }

    public static void Deactivate()
    {
        _active = false;
        Time.timeScale = 0f;
    }
    
    public static int GetWaveIndex()
    {
        return _waveIndex;
    }
    
    public static int GetEnemiesKilled()
    {
        return EnemiesKilled;
    }

    public static float GetCountdown()
    {
        return _countdown;
    }

    public static float GetEnemiesAlive()
    {
        return EnemiesAlive;
    }

    public static void ResetCountdown()
    {
        _countdown = TimeBetweenWaves;
    }
}
