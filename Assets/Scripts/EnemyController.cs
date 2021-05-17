using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [HideInInspector]
    public float Speed = 4f;
    [HideInInspector]
    public int Health = 1;

    private GameObject Player;

    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.LookAt(Player.transform);
        Move();
        if (transform.position.y < 0)
        {
            GameManager.Instance.NumOfEnemies++;
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
        GameManager.Instance.AfterEnemyDied();
        Destroy(gameObject);
    }
}
