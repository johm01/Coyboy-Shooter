using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance; 

    public Text Healthtext;
    public Player player;
    int hp = 5; 
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
        Healthtext.text = "Health: " + hp.ToString();
        if (hp <= 0)
        {
            hp = 0;
        }
    }

    public void TakeHealth(int health)
    {
        hp = hp - health;
    }

    public void AddHealth(int health)
    {
        hp = hp + health;
    }
   
}
