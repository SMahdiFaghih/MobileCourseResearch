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
    [Space]
    public Joystick MoveJoystick;
    public Joystick RotationJoystick;

    private Coroutine FireCoroutine = null;

    void Start()
    {
        FireCoroutine = StartCoroutine(Fire());
        IsLevelCompleted = false;
    }

    void Update()
    {
        if (!IsLevelCompleted)
        {
            Move();
            Rotate();
        }
        else
        {
            StopCoroutine(FireCoroutine);
        }
    }

    private void Move()
    {
        Rigidbody.velocity = (MoveJoystick.Horizontal * Vector3.right + MoveJoystick.Vertical * Vector3.forward) * Velocity;
    }

    private void Rotate()
    {
        transform.LookAt(transform.position + RotationJoystick.Horizontal * Vector3.right + RotationJoystick.Vertical * Vector3.forward);
    }

    private IEnumerator Fire()
    {
        while (true)
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
