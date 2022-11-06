using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] 
    private EnemiesSpawner _enemySpawner;
    
    [SerializeField] 
    private CameraController _actorController;

    [SerializeField] 
    private CanvasManager _canvasManager;
    
    [SerializeField] 
    private ShootingController _shootingController;

    [SerializeField] 
    private int _enemiesCount;
    private void Awake()
    {
        _enemySpawner.Initialize(_actorController,_enemiesCount);
        _canvasManager.Initialize(_enemiesCount,_shootingController.ShootingEvent,_enemySpawner.EnemyNeutralized);
        Debug.Log("GameManager Initialization");
    }
}
