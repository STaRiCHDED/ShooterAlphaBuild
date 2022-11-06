using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] 
    private EnemiesCounterUI _enemiesCounterUI;
    [SerializeField] 
    private BulletCounterUI _bulletCounterUI;

    private UnityEvent<int> _changeAmmo;
    private UnityEvent _enemyNeutralized;
    public void Initialize(int count,UnityEvent<int> changeAmmo,UnityEvent enemyNeutralized)
    {
        _enemiesCounterUI.Initialize(count);
        _changeAmmo = changeAmmo;
        _changeAmmo.AddListener(_bulletCounterUI.ChangeAmmoCount);
        _enemyNeutralized = enemyNeutralized;
        _enemyNeutralized.AddListener(_enemiesCounterUI.DecreaseEnemiesCount);
        Debug.Log("CanvasManager Initialization");
    }

    private void OnDestroy()
    {
        _changeAmmo.RemoveListener(_bulletCounterUI.ChangeAmmoCount);
        _enemyNeutralized.RemoveListener(_enemiesCounterUI.DecreaseEnemiesCount);
    }
}
