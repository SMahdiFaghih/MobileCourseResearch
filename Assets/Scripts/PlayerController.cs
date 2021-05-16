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
        Rigidbody.velocity = (Input.GetAxis("Horizontal") * Vector3.right + Input.GetAxis("Vertical") * Vector3.forward) * Velocity;
    }

    private void Rotate()
    {
        Plane plane = new Plane(Vector3.up, transform.position);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out float distance))
        {
            Vector3 hitPoint = ray.GetPoint(distance);
            transform.LookAt(hitPoint);
        }
    }

    private IEnumerator Fire()
    {
        while (true)
        {
            if (Input.GetAxis("Fire1") != 0)
            {
                Rigidbody bullet = Instantiate(BulletPrefab, LeftGunFireTransform.transform.position, LeftGunFireTransform.transform.rotation).GetComponent<Rigidbody>();
                bullet.velocity = transform.forward * BulletVelocity;
            }

            yield return new WaitForSeconds(0.05f);

            if (Input.GetAxis("Fire2") != 0)
            {
                Rigidbody bullet = Instantiate(BulletPrefab, RightGunFireTransform.transform.position, RightGunFireTransform.transform.rotation).GetComponent<Rigidbody>();
                bullet.velocity = transform.forward * BulletVelocity;
            }

            yield return new WaitForSeconds(0.05f);

        }
    }
}
