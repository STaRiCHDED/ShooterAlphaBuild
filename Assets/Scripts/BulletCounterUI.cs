using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletCounterUI : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI _text;

    private const int MAGAZINE_SIZE = 20;
    private void Awake()
    {
        _text.text = MAGAZINE_SIZE.ToString();
    }

    public void ChangeAmmoCount(int value)
    {
        _text.text = value.ToString();
    }
}
