using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject mob;
    private GameObject spawnedmob;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMob());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator SpawnMob()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 10));
            spawnedmob = Instantiate(mob, transform.position, transform.rotation);
        }
    }
}
