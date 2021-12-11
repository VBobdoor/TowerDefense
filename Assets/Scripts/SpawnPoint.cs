using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    [SerializeField] private int currentWave = 1;
    [SerializeField] private float currentEnemyInWave = 1f;
    [SerializeField] private float waveEnemyMultiplaer = 1.5f;
    [SerializeField] private float spawnCooldownMultiplaer = 0.03f;
    [SerializeField] private float spawnCooldown = 2f;
    [SerializeField] private float waveCooldown = 5f;

    private bool ableToSpawn = true;
    private bool isWaveStarted = false;

    private Transform targetPoint;

    public Transform TargetPoint
    {
        set
        {
            targetPoint = value;
        }
    }

    private void Start()
    {
        StartCoroutine(WaveBreak());
    }

    private void Update()
    {
        if (ableToSpawn && isWaveStarted && currentEnemyInWave > 0)
        {
            SpawnEnemy();
            StartCoroutine(SetSpawnCoolDown());
        }
        else if (currentEnemyInWave <= 0)
        {
            StartCoroutine(WaveBreak());
            ChangeWaveSettings();
        }
    }

    private void SpawnEnemy()
    {
        currentEnemyInWave -= 1;
        GameObject currentEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
        NavMeshAgent agent = currentEnemy.GetComponent<NavMeshAgent>();
        agent.destination = targetPoint.position;
    }
    
    private IEnumerator SetSpawnCoolDown()
    {
        ableToSpawn = false;
        yield return new WaitForSeconds(spawnCooldown);
        ableToSpawn = true;
    }

    private IEnumerator WaveBreak()
    {
        isWaveStarted = false;
        yield return new WaitForSeconds(waveCooldown);
        RefreshWaveText();
        isWaveStarted = true;
    }

    private void ChangeWaveSettings()
    {
        currentWave += 1;
        currentEnemyInWave += currentWave * waveEnemyMultiplaer;
        if (spawnCooldown - currentWave * spawnCooldownMultiplaer > 0.1)
            spawnCooldown -= currentWave * spawnCooldownMultiplaer;
        else
            spawnCooldown = 0.1f;
    }
    
    private void RefreshWaveText()
    {
        UITextManager.uITextManager.SetCurrentWaveText(currentWave.ToString());
    }
}
