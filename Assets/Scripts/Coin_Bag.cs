using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Bag : MonoBehaviour
{
    int randomNum;
    // Start is called before the first frame update
    void Start()
    {
       randomNum = Random.Range(1, 6);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Player>(out Player other))
        {
            other.coins = other.coins + randomNum;
            Debug.Log(other.coins);
            Destroy(gameObject);
            CoinText.instance.UpdateCoin(randomNum);

        }
    }
}
