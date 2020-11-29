using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] float shotCounter;
    [SerializeField] GameObject enemyLaserPrefab;
    [SerializeField] float minTimeBeforeShooting = 0.2f;
    [SerializeField] float maxTimeBeforeShooting = 3f;
    [SerializeField] GameObject deathVFX;
    void Start()
    {
        shotCounter = UnityEngine.Random.Range(minTimeBeforeShooting, maxTimeBeforeShooting);
    }

    // Update is called once per frame
    void Update()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0)
        {
            Fire();
            shotCounter = UnityEngine.Random.Range(minTimeBeforeShooting, maxTimeBeforeShooting);
        }
    }

    private void Fire()
    {
        GameObject laser = Instantiate(
                enemyLaserPrefab,
                transform.position,
                Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -10f);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Destroy destroy = other.gameObject.GetComponent<Destroy>();
        destroy.Hit();
        health -= 100;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        GameObject particle = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(particle, 1f);

    }
}
