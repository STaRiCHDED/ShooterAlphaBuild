using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyMovementController : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private const float ENEMY_CENTER = 2f;
    private CameraController _actor;

    private UnityEvent _enemyNeutralized;

    public void Initialize(CameraController actor,UnityEvent unityEvent)
    {
        _actor = actor;
        _enemyNeutralized = unityEvent;
        Debug.Log("EnemyMovement Initialization");
    }
    
    void Update()
    {
         var actorPosition = _actor.transform.position;
        //Debug.Log($"Actor position {_actorPosition}");
        var target = new Vector3(actorPosition.x, ENEMY_CENTER, actorPosition.z);
        transform.LookAt(target);
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * _speed);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sandbox") || collision.gameObject.CompareTag("Enemy"))
        {
            return;
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log($"Enemy neutralized by {collision.gameObject.name}");
            Destroy(gameObject);
            _enemyNeutralized?.Invoke();
        }
    }
}
