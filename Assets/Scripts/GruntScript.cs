using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntScript : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject Bimo;

    private float lastShootTime;
    private float shootInterval = 1.0f; // Intervalo de tiempo entre disparos
    private int health = 2;

    // Ajusta el valor de alcance aquí
    public float AttackRange = 3.0f;

    // Update is called once per frame
    void Update()
    {
        if (Bimo == null) return;

        // Calcula la distancia entre Grunt y Bimo
        float distance = Vector3.Distance(Bimo.transform.position, transform.position);

        // Verifica si Bimo está dentro del alcance
        if (distance <= AttackRange)
        {
            Vector2 direction = Bimo.transform.position - transform.position;

            if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

            // Dispara una bala cada cierto tiempo
            if (Time.timeSinceLevelLoad > lastShootTime + shootInterval)
            {
                Shoot();
                lastShootTime = Time.timeSinceLevelLoad;
            }
        }
    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector2.right;
        else direction = Vector3.left;

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    public void Hit()
    {
        health--;
        if (health == 0) Destroy(gameObject);
    }
}
