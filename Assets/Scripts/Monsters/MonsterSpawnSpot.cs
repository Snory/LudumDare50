using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MonsterSpawnSpot : MonoBehaviour
{
    public List<MonsterType> MonsterTypes;
        
    public GameObject MonsterPrefab;
    
    [SerializeField]
    private GameObject _toBuyGameObject;

    [SerializeField]
    private Player _player;

    [SerializeField]
    private GlobalEvent _monsterSpawned;

    [SerializeField]
    private MonsterSpawnSpotEvent _spawnedSpotCreated;

    [SerializeField]
    private float _freeSpotAfterSeconds;

    public bool SpawnSpotFull;

    private void Awake()
    {
        _toBuyGameObject.SetActive(true);
        SpawnSpotFull = false;
    }

    private void Start()
    {
        RaiseSpawnSpotCreated(this);
    }

    public void OnSpawnMonsterRequest()
    {
        _toBuyGameObject.SetActive(false);
        GameObject monster = Instantiate(MonsterPrefab, this.transform);
        int random = Random.Range(0, MonsterTypes.Count);
        MonsterType monsterType = MonsterTypes[random];
        MonsterNeeds monsterNeeds = monster.GetComponent<MonsterNeeds>();
        MonsterNeedsCycle monsterNeedsCycle = monster.GetComponent<MonsterNeedsCycle>();
        MonsterSelector monsterSelector = monster.GetComponentInChildren<MonsterSelector>();
        MonsterActions monsterActions = monster.GetComponentInChildren<MonsterActions>();
        MonsterLook monsterLook = monster.GetComponentInChildren<MonsterLook>();


        monsterNeeds.MonsterType = monsterType;
        monsterLook.SetMonsterLook(monsterType.MonsterSprite);
        monsterNeedsCycle.MonsterType = monsterType;
        _player.MonsterSelected.AddListener(monsterSelector.OnSelected);
        monsterNeeds.MonsterSold.AddListener(this.OnMonsterSold);

        //init monster
        monsterNeeds.Init();
        SpawnSpotFull = true;
        OnMonsterSpawned();
    }

    public IEnumerator FreeSpot() {

        yield return new WaitForSeconds(_freeSpotAfterSeconds);
        if (_toBuyGameObject.activeSelf)
        {
            SpawnSpotFull = false;
        }
    }

    public void OnSelected()
    {
        OnSpawnMonsterRequest();
    }


    public void OnMonsterSold()
    {
        _toBuyGameObject.SetActive(true);
        StartCoroutine(FreeSpot());
    }

    public void OnMonsterSpawned()
    {
        if(_monsterSpawned != null)
        {
            _monsterSpawned.Raise();
        }
    }

    private void RaiseSpawnSpotCreated(MonsterSpawnSpot monsterSpawnSpot)
    {
        if (_spawnedSpotCreated != null)
        {
            _spawnedSpotCreated.Raise(this);
        }
    }



    
}
