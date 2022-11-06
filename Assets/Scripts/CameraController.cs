using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] 
    private float _rotationSpeed;
    [SerializeField] 
    private float _speed;
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        Debug.Log($"{horizontal} {vertical}");
        transform.Translate(Vector3.forward * vertical*_speed * Time.deltaTime);
        transform.Rotate(0, horizontal * _rotationSpeed, 0);
    }
}
