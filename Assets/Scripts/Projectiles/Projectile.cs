using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] float lifetime;
    public float damage, speed, pierce;
    private float life;
    private Vector2 moveDirection;
    GameObject target;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GetTarget();

        if (target) {
            Vector3 direction = (target.transform.position - transform.position).normalized;
            rb.rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            moveDirection = direction;
        }
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        life += Time.deltaTime;
        if (life >= lifetime) {
            Destroy(gameObject);
        }
    }

    public void SetDamage(float damage) {
        this.damage = damage;
    }

    public void SetPierce(float pierce) {
        this.pierce = pierce;
    }

    protected abstract GameObject GetTarget();

    protected abstract void OnTriggerEnter2D(Collider2D other);
    
    protected void Hit(GameObject other) {

        IDamagable targetBody = other.GetComponent<IDamagable>();
        targetBody.TakeDamage(damage);
        if (pierce <= 1) {
            Destroy(gameObject);
        } else {
            pierce--;
        }
    }
}
