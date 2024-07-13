using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float _spawnDelay;
    [SerializeField] private Player player;
    private SpawnPosition[] _spawnPositions;

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform enemyPoolParent;
    private ObjectPool<Enemy> _enemyPool;

    private void Awake()
    {
        _enemyPool = new(enemyPrefab, enemyPoolParent.transform, 30);
        _spawnPositions = GetComponentsInChildren<SpawnPosition>();
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            _spawnDelay = Random.Range(1.75f, 3f);
            yield return new WaitForSeconds(_spawnDelay);

            Enemy enemy = _enemyPool.Pull();
            Vector3 spawnPosition = _spawnPositions[Random.Range(0, _spawnPositions.Length)].transform.position;

            enemy.gameObject.SetActive(true);
            enemy.Initialize(spawnPosition);

            enemy.SetTarget(player.transform);
        }
    }
}
