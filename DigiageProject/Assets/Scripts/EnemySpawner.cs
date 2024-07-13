using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float _spawnDelay;
    [SerializeField] private Player player;
    private SpawnPosition[] _spawnPositions;

    [SerializeField] private GameObject enemyPrefabOne;
    [SerializeField] private GameObject enemyPrefabTwo;
    [SerializeField] private GameObject enemyPrefabThree;
    [SerializeField] private Transform enemyPoolParent;
    private ObjectPool<Enemy> _enemyPoolOne;
    private ObjectPool<Enemy> _enemyPoolTwo;
    private ObjectPool<Enemy> _enemyPoolThree;

    private void Awake()
    {
        _enemyPoolOne = new(enemyPrefabOne, enemyPoolParent.transform, 30);
        _enemyPoolTwo = new(enemyPrefabTwo, enemyPoolParent.transform, 30);
        _enemyPoolThree = new(enemyPrefabThree, enemyPoolParent.transform, 30);
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
            int poolNum = Random.Range(0, 3);
            _spawnDelay = Random.Range(2f, 5f);
            yield return new WaitForSeconds(_spawnDelay);

            Enemy enemy;

            switch (poolNum)
            {
                case 0:
                    enemy = _enemyPoolOne.Pull();
                    break;
                case 1:
                    enemy = _enemyPoolTwo.Pull();
                    break;
                case 2:
                    enemy = _enemyPoolThree.Pull();
                    break;
                default:
                    enemy = _enemyPoolOne.Pull();
                    break;
            }

            Vector3 spawnPosition = _spawnPositions[Random.Range(0, _spawnPositions.Length)].transform.position;

            enemy.gameObject.SetActive(true);
            enemy.Initialize(spawnPosition);

            enemy.SetTarget(player.transform);
        }
    }
}
