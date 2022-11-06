using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] 
    private EnemyMovementController _enemy;

    private CameraController _actorController;
    private int _count;

    [HideInInspector] 
    public UnityEvent EnemyNeutralized;

    public void Initialize(CameraController actor,int count)
    {
        _actorController = actor;
        _count = count;
        Debug.Log("EnemiesSpawner Initialization");
    }
    private void Start()
    {
        for (int i = 0; i < _count; i++)
        {
            SpawnEnemy();
        }
    }
    private void SpawnEnemy()
    {
        var newActor = Instantiate(_enemy);
        Debug.Log("Spawn Enemy");
        newActor.Initialize(_actorController,EnemyNeutralized);
        newActor.transform.position = new Vector3(Random.Range(-30,30), _enemy.transform.localScale.y/2 + 0.5f, Random.Range(-30,30));
    }
}
