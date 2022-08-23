using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Coffin : MonoBehaviour
{
    public int hp;
    public float deathtimer;
    private Animator anim;
    public Transform attackPoint;
    public float attackrange;
    public LayerMask enemyLayers;
    public int attackDmg;
   
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthCheck();
    }
    IEnumerator Death()
    {
        anim.SetTrigger("death");
        yield return new WaitForSeconds(deathtimer);
        Destroy(gameObject);
        GameText.instance.AddScore(1);

    }

    public void TakeDmg(int dmg)
    {
        hp = hp - dmg;
    }

   

    void Attack()
    {
        anim.SetTrigger("attack");
        Collider2D[] hitenemies = Physics2D.OverlapCircleAll(attackPoint.position, attackrange, enemyLayers);
        foreach(Collider2D enemy in hitenemies)
        {
            Debug.Log("HIT");
            // When the player is hit 
            enemy.GetComponent<Player>().TakeDmg(attackDmg);

        }
    }

    public void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackrange);
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
      
    }
}
