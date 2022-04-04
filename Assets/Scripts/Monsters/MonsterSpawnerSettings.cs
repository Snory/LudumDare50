using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMonsterSpawnerSetting", menuName = "Spawner/MonsterSpawner", order = 1)]
public class MonsterSpawnerSettings : ScriptableObject
{
    public List<MonsterSpawnerScoreFrequency> SpawnerFrequencySettings;
}
