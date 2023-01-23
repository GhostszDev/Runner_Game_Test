using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _manager : MonoBehaviour
{
    
    //public vars
    public bool is2D;

    //private vars
    private GameObject _player;

    private void Awake()
    {
        if (!_player)
        {
            _player = GameObject.FindWithTag("Player");
        }
        
        if (is2D)
        {
            if (!_player.gameObject.GetComponent<_controls_2D>())
            {
                _player.gameObject.AddComponent<_controls_2D>();
            }
        }
        else
        {
            if (!_player.gameObject.GetComponent<_controls_3D>())
            {
                _player.gameObject.AddComponent<_controls_3D>();
            }
        }
        
    }
}
