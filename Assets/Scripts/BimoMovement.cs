using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BimoMovement : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float speed = 7.0f; // velocidad de movimiento
    public float jumpForce = 35.0f;
    public float fallBoundary = -10f; // Límite inferior para detectar caída al vacío

    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private float horizontal;
    private bool Grounded;
    private float LastShoot;
    private int Health = 10;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        animator.SetBool("running", horizontal != 0.0f);

        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;
        }
        else Grounded = false;

        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.Space) && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }

        // Detectar si el personaje ha caído al vacío
        if (transform.position.y <= fallBoundary)
        {
            Over.show();
            Destroy(gameObject);
        }
    }

    private void Jump()
    {
        rigidbody2D.AddForce(Vector2.up * jumpForce);
    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector2.right;
        else direction = Vector3.left;

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(horizontal * speed, rigidbody2D.velocity.y);
    }

    public void Hit()
    {
        Health = Health - 1;
        if (Health == 0)
        {
            Over.show ();
            Destroy(gameObject);
        }

    }
}