using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CoinText : MonoBehaviour
{
    public static CoinText instance;
    public Text text;
    public Player player;
    int coin = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateCoin(int coinamt)
    {
        coin = coin + coinamt;
        text.text = "Coins: " +  coin;

    }
}
