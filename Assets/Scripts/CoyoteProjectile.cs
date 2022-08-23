using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoyoteProjectile : MonoBehaviour
{
    public float speed;
    public int dmg;
    public int destroyTimer;
    public GameObject particle; 
    Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = FindObjectOfType<Player>().transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        TransformBullet();
    }

    private void DestroyBullet()
    {
        Instantiate(particle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void TransformBullet()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        if (transform.position == targetPos)
        {
            DestroyBullet();
        }
    }

    void Parry()
    {
        targetPos = FindObjectOfType<Enemy_Coyote>().transform.position;
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Bullet>(out Bullet bullet))
        {
            Parry();
        }
        else
        {
            DestroyBullet();
        }
    }
}
