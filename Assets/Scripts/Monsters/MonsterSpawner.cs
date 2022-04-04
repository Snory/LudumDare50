using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private MonsterSpawnerSettings _spawnerSettings;

    [SerializeField]
    private int _countOfSpawnedMonsters;

    [SerializeField]
    private List<MonsterSpawnSpot> _spawnSpots;

    [SerializeField]
    private bool _spawning;

    [SerializeField]
    private float _spawnCoolDown;

    private void Awake()
    {
        _countOfSpawnedMonsters = 0;
    }


    public void OnUpdatedScore(float score)
    {
        if (score <= 0) return;
        //check score
        MonsterSpawnerScoreFrequency mssf = _spawnerSettings.SpawnerFrequencySettings.Where(sfs => sfs.MinimumScoreLevelAmount <= score).OrderByDescending(sfs => sfs.MinimumScoreLevelAmount).FirstOrDefault();

        if (mssf == null)
        {
            Debug.LogError("[MonsterSpawner]: Missing configuration");
        }
        
        //compare count of monster spawned with count of needed
        if (mssf.CountOfMonstersOnScoreLevel > _countOfSpawnedMonsters && !_spawning)
        {
            StartCoroutine(SpawnMonsters(mssf.CountOfMonstersOnScoreLevel - _countOfSpawnedMonsters));
        }
    }

    private IEnumerator SpawnMonsters(int countOfMonstersToSpawn)
    {
        int spawnedCount = 0;
        _spawning = true;

        while (_spawnSpots.Exists(s => !s.SpawnSpotFull) && spawnedCount < countOfMonstersToSpawn)
        {
            _spawnSpots.Where(s => !s.SpawnSpotFull).First().OnSpawnMonsterRequest();
            spawnedCount++;
            yield return new WaitForSeconds(_spawnCoolDown);


        }
        _spawning = false;

    }


    public void OnMonsterSpawned()
    {
        _countOfSpawnedMonsters++;
    }

    public void OnMonsterDestroyed()
    {
        _countOfSpawnedMonsters--;
    }

    public void OnSpawnSpotCreated(MonsterSpawnSpot spawn)
    {
        _spawnSpots.Add(spawn);
    }
}
