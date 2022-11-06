using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesCounterUI : MonoBehaviour
{
    [SerializeField] 
    private Transform _parent;
    
    [SerializeField] 
    private Image _image;
    
    private int _enemyCount;
    private List<Image> _imagesList;

    public void Initialize(int count)
    {
        _enemyCount = count;
        Debug.Log("EnemiesCounterUI Initialization");
    }
    private void Start()
    {
        _imagesList = new List<Image>();
        for (int i = 0; i < _enemyCount; i++)
        {
            var enemy = Instantiate(_image, _parent);
            _imagesList.Add(enemy);
        }
    }

    public void DecreaseEnemiesCount()
    {
        if(_enemyCount == 0)
            return;
        Destroy(_imagesList[_enemyCount-1]);
        _imagesList[_enemyCount - 1] = null;
        _enemyCount--;
    }
}
