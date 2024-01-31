using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{

    public float health, maxHealth, moveSpeed, damage;
    [SerializeField] float attackCoolDown;
    private Player player;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private float lastAttackedAt = -99999f;


    // Awake is called upon instantialization of the game object this script is attached to
    void Awake() 
    {
       rb = GetComponent<Rigidbody2D>();
       this.health = this.maxHealth;
       GameObject playerGameObj = GameObject.FindGameObjectWithTag("Player");
       if (playerGameObj) {
        player = playerGameObj.GetComponent<Player>();
       }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (player) {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            moveDirection = direction;
        }   
    }

    void FixedUpdate() {
        if (player) {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }

    public void TakeDamage(float damageAmount) {
        health -= damageAmount;

        if (health <= 0) {
            Destroy(gameObject);
        }
    }


    /// <summary>
    /// Sent each frame where a collider on another object is touching
    /// this object's collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player") {
            if (Time.time > lastAttackedAt + attackCoolDown) {
                player.TakeDamage(damage);
                lastAttackedAt = Time.time;
            }
        }
    }
}
