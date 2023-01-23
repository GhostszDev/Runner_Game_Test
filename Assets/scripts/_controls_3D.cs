using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class _controls_3D : MonoBehaviour
{

    //public vars
    public GameObject[] prefabs;
    public GameObject character, left, middle, right;

    //private vars
    public Rigidbody rb;
    private GameObject selectedPlayer;

    private void AssignPrefabs()
    {
        prefabs = Resources.LoadAll<GameObject>("actors/players");
    }

    private void GetSpots()
    {

        character = this.gameObject.transform.GetChild(3).gameObject;
        left = this.gameObject.transform.GetChild(0).gameObject;
        middle = this.gameObject.transform.GetChild(1).gameObject;
        right = this.gameObject.transform.GetChild(2).gameObject;
    }

    private void Awake()
    {
        AssignPrefabs();
        GetSpots();
        if (!selectedPlayer)
        {
            selectedPlayer = Instantiate(prefabs[0], character.transform);
        }

        if (!rb)
        {
            rb = selectedPlayer.AddComponent<Rigidbody>();
        }
    }
}
