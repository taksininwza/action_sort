using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed = 12;
    [SerializeField] float bulletLifeTime = 2f;
    [SerializeField] float fireingRate = 0.2f;

    public bool isFiring = false;
    Coroutine firingCoroutine;

    private void Update()
    {
        fire();
    }

    private void fire()
    {
        if (isFiring == true && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(firecontinuosely());
        }
        else if (isFiring == false && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    private IEnumerator firecontinuosely()
    {
        while (true)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rigidbodyBullet = bullet.GetComponent<Rigidbody2D>();
            if (rigidbodyBullet != null)
            {
                rigidbodyBullet.velocity = transform.up * bulletSpeed;
            }
            Destroy(bullet, bulletLifeTime);
            yield return new WaitForSeconds(fireingRate);
        }
    }
}
