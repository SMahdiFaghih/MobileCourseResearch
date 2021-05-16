using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerController PlayerController;
    private bool LevelCompleted = false;

    void Start()
    {
        PlayerController = GetComponent<PlayerController>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!LevelCompleted)
        {
            if (collision.collider.tag == "Enemy")
            {
                GameManager.Instance.Restart();
            }
        }
    }
}
