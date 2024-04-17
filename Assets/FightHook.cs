using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

// NEEDS TO BE USED FOR BOSS FIGHT, THIS IS A DIFFERENT HOOK
public class FightHook : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    public GameObject projPrefab;
    public Transform shootPoint;

    public float shootingCooldown = 0.5f;
    private float shootTimer = 0f;

    

    

    private float timer;
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * speed * Time.deltaTime);

        if(Input.GetButtonDown("Fire1") && Time.time >= shootTimer)
        {
            ShootProjectile();

            shootTimer = Time.time + shootingCooldown;
        }

    }

    void ShootProjectile()
    {
        GameObject newProjectile = Instantiate(projPrefab, shootPoint.position, shootPoint.rotation);
    }

    public void PlayerDeath()
    {
        Destroy(gameObject);
    }

    



}