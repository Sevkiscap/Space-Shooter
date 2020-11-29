using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int health = 400;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileVelocity = 20f;
    [SerializeField] float projectileFiringPeriod = 0.05f;
        float xMin;
        float xMax;
        float yMin;
        float yMax;
    Coroutine firingCoroutine;

        // Use this for initialization
        void Start()
        {
            SetUpMoveBoundaries();
        }


            private void SetUpMoveBoundaries()
            {
                Camera gameCamera = Camera.main;
                xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
                xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
                yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
                yMax = gameCamera.ViewportToWorldPoint(new Vector3(0,2, 0)).y - padding;
            }

            // Update is called once per frame
            void Update()
            {
                Move();
            if (Input.GetButtonDown("Fire1"))
                 {
                    firingCoroutine = StartCoroutine(FireContiniously());
                 }
            if (Input.GetButtonUp("Fire1"))
            {
            StopCoroutine(firingCoroutine);        
            }
            
            }
    public void OnTriggerEnter2D(Collider2D other)
    {
        Destroy destroy = other.gameObject.GetComponent<Destroy>();
        destroy.Hit();
        health -= 100;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        
    }
    IEnumerator FireContiniously()
    {
        while (true)
        {
            GameObject laser = Instantiate(
                laserPrefab,
                transform.position,
                Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileVelocity); laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileVelocity);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
        
    }
    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);
    }
}
    
    

    

        
