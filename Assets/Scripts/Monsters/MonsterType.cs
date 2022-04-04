using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMonsterType", menuName = "Monster/MonsterType", order = 1)]
public class MonsterType : ScriptableObject
{
    public List<MonsterNeedsCycleTime> MonsterNeedCycleTimes;
    public List<NeedCategory> Needs;
    public float MinimumSellLevel = 3;
    public float MaximumStockGeneration = 10;
    public float SellValuePerLevel = 10;
    public Sprite MonsterSprite;

}
