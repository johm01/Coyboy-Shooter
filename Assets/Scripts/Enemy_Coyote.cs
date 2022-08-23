using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Coyote : MonoBehaviour
{
    public float hp;
    private int random;
    private Animator anim;
    public GameObject bullet;
    public Transform LaunchPos;
    public float timebetweenshots;
    public float nextShotTime;
    public LayerMask enemyLayer;
    public float attackrange;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    IEnumerator Death()
    {
        anim.SetTrigger("death");
        GameText.instance.AddScore(3);
        yield return new WaitForSeconds(.1f);
        Destroy(gameObject);
    }

    void Attack()
    {
        if (Time.time > nextShotTime)
        {
            anim.SetBool("attack", true);
            Instantiate(bullet, LaunchPos.position, Quaternion.identity);
            nextShotTime = Time.time + timebetweenshots;
        }

        Collider2D[] hitenemies = Physics2D.OverlapCircleAll(LaunchPos.position, attackrange, enemyLayer);
        foreach(Collider2D enemy in hitenemies)
        {
            //Instantiate(bullet, LaunchPos.position, Quaternion.identity);
        }
    }

    public void OnDrawGizmosSelected()
    {
        if (LaunchPos == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(LaunchPos.position, attackrange);
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
        if(collision.gameObject.TryGetComponent<CoyoteProjectile>(out CoyoteProjectile projectile))
        {
            TakeDmg(projectile.dmg);
        }
    }
}
