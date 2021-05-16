﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [HideInInspector]
    public static bool IsLevelCompleted = false;
    [HideInInspector]
    public float Speed = 4f;
    [HideInInspector]
    public int Health = 1;

    private GameObject Player;

    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        IsLevelCompleted = false;
    }

    void Update()
    {
        transform.LookAt(Player.transform);
        if (!IsLevelCompleted)
        {
            Move();
        }
        if (transform.position.y < 0)
        {
            GameManager.Instance.numOfEnemies++;
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        float step = Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, step);
    }

    public void ReduceHealth()
    {
        GameManager.Instance.numOfEnemies++;
        Destroy(gameObject);
    }
}