using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Projectile
{
    override protected GameObject GetTarget() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        return player;
    }
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") {
            Hit(other.gameObject);
        }
    }
}
