using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMonster", menuName = "Monster/Monster", order = 1)]
public class Monster : ScriptableObject
{
    public List<MonsterNeedsCycleTime> MonsterNeedCycleTimes;
    public List<NeedCategory> Needs;


}
