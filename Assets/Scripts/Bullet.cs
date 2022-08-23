using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D myBody;
    public GameObject ParticleEffect;
    public float force;
    public int bullet_dmg;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        myBody = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;

        myBody.velocity = new Vector2(direction.x, direction.y).normalized * force;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
        Instantiate(ParticleEffect, transform.position, transform.rotation);

        if (other.gameObject.TryGetComponent<Enemy_Coffin>(out Enemy_Coffin other_2))
        {
            other_2.TakeDmg(bullet_dmg);
            other_2.HealthCheck();
        }

        if(other.gameObject.TryGetComponent<Enemy_Coyote>(out Enemy_Coyote other_4))
        {
            other_4.TakeDmg(bullet_dmg);
            other_4.HealthCheck();
        }

    }
}
