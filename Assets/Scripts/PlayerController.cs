using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public static bool IsLevelCompleted = false;

    public int Velocity = 5;
    public int BulletVelocity = 20;

    public GameObject BulletPrefab;

    public Rigidbody Rigidbody;
    public GameObject LeftGunFireTransform;
    public GameObject RightGunFireTransform;

    private Joystick Joystick;
    public JoyButton JoyButton;

    private Coroutine FireCoroutine = null;

    void Start()
    {
        Joystick = FindObjectOfType<Joystick>();
        JoyButton = FindObjectOfType<JoyButton>();

        FireCoroutine = StartCoroutine(Fire());
        IsLevelCompleted = false;
    }

    void Update()
    {
        if (!IsLevelCompleted)
        {
            Move();
        }
        else
        {
            StopCoroutine(FireCoroutine);
        }
    }

    private void Move()
    {
        Rigidbody.velocity = (Joystick.Horizontal * Vector3.right + Joystick.Vertical * Vector3.forward) * Velocity;
        transform.LookAt(transform.position + Joystick.Horizontal * Vector3.right + Joystick.Vertical * Vector3.forward);
    }

    private IEnumerator Fire()
    {
        while (true)
        {
            if (JoyButton.buttonPressed)
            {
                Rigidbody leftBullet = Instantiate(BulletPrefab, LeftGunFireTransform.transform.position, LeftGunFireTransform.transform.rotation).GetComponent<Rigidbody>();
                leftBullet.velocity = transform.forward * BulletVelocity;

                yield return new WaitForSeconds(0.05f);

                Rigidbody rightBullet = Instantiate(BulletPrefab, RightGunFireTransform.transform.position, RightGunFireTransform.transform.rotation).GetComponent<Rigidbody>();
                rightBullet.velocity = transform.forward * BulletVelocity;

                yield return new WaitForSeconds(0.05f);
            }
        }
    }
}
