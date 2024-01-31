using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerWeapon : MonoBehaviour
{
    public float damage;
    [SerializeField] float attackCoolDown;
    [SerializeField] GameObject projectileGameObj;
    Projectile projectile;
    private float timer = 0f;
    private float attackCoolDownMultiplier = 1;
    private float damageMultiplier = 1;
    private int additionalShots = 1;


    private void Awake() {
        //enemyProjectile = projectileGameObj.GetComponent<EnemyProjectile>();
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

    // override this for different amounts of shots
    private void Shoot() {
        //enemyProjectile.SetDamage(damage);
        //Instantiate(projectile, transform.position, Quaternion.identity);
    }

    // multiplier sources need to be added up before being set here.
    public void SetAttackSpeedMultiplier(float attackCoolDownMultiplier) {
        this.attackCoolDownMultiplier = attackCoolDownMultiplier;
    }

    public void SetDamageMultiplier(float damageMultiplier) {
        this.damageMultiplier = damageMultiplier;
    }

    public void SetAdditionalShots(int additionalShots) {
        this.additionalShots = additionalShots;
    }

    public abstract void LevelUp();
}
