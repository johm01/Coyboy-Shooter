using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Cactus : MonoBehaviour
{
    public int hp;
    private Animator anim;
    public float speed;
    public float deathtimer;
    private int random;
    public GameObject ItemDrop;
    private Rigidbody2D myBody;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    IEnumerator Death()
    {
        anim.SetTrigger("death");
        myBody.velocity = new Vector2(0f, 0f);
        random = Random.Range(1, 11);
        if (random >= 10)
        {
            Instantiate(ItemDrop, transform.position, transform.rotation);
        }
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
        GameText.instance.AddScore(2);
    }

    public void TakeDmg(int dmg)
    {
        hp = hp - dmg;
    }

    public void HealthCheck()
    {
        if (hp <= 0)
        {
            StartCoroutine(Death());

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Bullet>(out Bullet bullet))
        {
            TakeDmg(bullet.bullet_dmg);
            HealthCheck();
        }
    }
}
