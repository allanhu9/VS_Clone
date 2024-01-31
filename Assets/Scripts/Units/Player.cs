using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable
{

    Rigidbody2D body;   
    public float speed = 1, maxHealth = 100, currentHealth = 0;
    [SerializeField] float diagonalMultiplier = 0.7f;
    float horizontal;
    float vertical;
    bool facingRight = true;
    private HealthBar healthBar;
    private ExperienceBar experienceBar;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        GameObject healthBarGameObj = GameObject.FindGameObjectWithTag("HealthBar");
        GameObject expBarGameObj = GameObject.FindGameObjectWithTag("ExperienceBar");
        if (healthBarGameObj) {
            healthBar = healthBarGameObj.GetComponent<HealthBar>();
        }
        if (expBarGameObj) {
            experienceBar = expBarGameObj.GetComponent<ExperienceBar>();
        }
        healthBar.SetMaxHealth(maxHealth);
        experienceBar.SetExperience(0);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if (horizontal != 0 && vertical != 0) {
            horizontal *= diagonalMultiplier;
            vertical *= diagonalMultiplier;
        }

        if (facingRight && horizontal < 0) {
            body.SetRotation(90);
            facingRight = false;
        } else if (!facingRight && horizontal > 0) {
            body.SetRotation(-90);
            facingRight = true;
        }
        
    }

    private void FixedUpdate() {
        body.velocity = new Vector2(horizontal * speed, vertical * speed);
    }
    
    public void TakeDamage (float damage) {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
