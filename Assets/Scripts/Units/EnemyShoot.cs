using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public float damage;
    [SerializeField] float attackCoolDown;
    [SerializeField] GameObject projectileGameObj;
    EnemyProjectile enemyProjectile;
    private float timer = 0f;


    private void Awake() {
        enemyProjectile = projectileGameObj.GetComponent<EnemyProjectile>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > attackCoolDown) {
            timer = 0;
            Shoot();
        }
    }

    private void Shoot() {
        enemyProjectile.SetDamage(damage);
        enemyProjectile.SetPierce(1);
        Instantiate(enemyProjectile, transform.position, Quaternion.identity);
    }
}
