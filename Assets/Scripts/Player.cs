using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public int hp;
    public int coins;
    private float movementX, movementY;

    private Transform trans;
    private Animator anim;
    private SpriteRenderer sr;
    private Rigidbody2D myBody;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        myBody.freezeRotation = true;
        
    }

    void HealthUpdate(int dmg) {
        hp = hp - dmg;

        if (hp <= 0) {
            Destroy(gameObject);
        }

        PlayerHealth.instance.TakeHealth(dmg);
    }
    
    void Movement()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        movementY = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(movementX, movementY, 0f) * speed * Time.deltaTime;

        // Walking Left and right
        if (movementX>0)
        {
            sr.flipX = false;
            anim.SetBool("walk", true);
        }
        else if(movementX < 0)
        {
            sr.flipX = true;
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }

        // Walking up and down
        if(movementY > 0)
        {
            anim.SetBool("walking_up", true);
        }
        else if(movementY < 0)
        {
            anim.SetBool("walking_down", true);
        }
        else
        {
            anim.SetBool("walking_up", false);
            anim.SetBool("walking_down", false);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<CoyoteProjectile>(out CoyoteProjectile projectile))
        {
          
           HealthUpdate(projectile.dmg);
        }
        
        if(collision.gameObject.TryGetComponent<Enemy_Cactus>(out Enemy_Cactus enemy)) {
           HealthUpdate(enemy.dmg);

        }
    }
}
