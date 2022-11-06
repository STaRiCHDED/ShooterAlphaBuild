using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootingController : MonoBehaviour
{
    [SerializeField] 
    private GameObject _bullet;
    [SerializeField]
    private float _bulletVelocity = 60f;
    [SerializeField]
    private int _ammo= 20;
    [HideInInspector]
    public UnityEvent<int> ShootingEvent;
    
    private const float MUZZLE_COORDINATES = 2.5f;
    private float _timeDelay = 2f;
    private float _currentTime;
    
    
    private void Update()
    {
        _currentTime += Time.deltaTime;
        if(Input.GetMouseButtonDown(0) && _currentTime > _timeDelay && _ammo > 0)
        {
            var newBullet = Instantiate(_bullet,transform.position + transform.forward * MUZZLE_COORDINATES,transform.localRotation);
            newBullet.GetComponent<Rigidbody>().velocity = transform.forward * _bulletVelocity;
            _ammo--;
            ShootingEvent?.Invoke(_ammo);
            _currentTime = 0f;
        }
    }
}
