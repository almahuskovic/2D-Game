using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public  class PlayerHealthLife : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private  int virusDamage;
    [SerializeField]
    private  int fakeNewsDamage;
    [SerializeField]
    private  int blueGlovesBonus;
    [SerializeField]
    private  int whiteGlovesBonus;
    [SerializeField]
    private  int maskBonus;
#pragma warning restore 0649
    public static int health { get; set; } = 100;
    public HealthBar healthBar;

    private void Start()
    {
        healthBar.SetMaxValue(health);
    }
    public void Damage(int damage)
    {
        if (health - damage <= 0)
        {
           FindObjectOfType<GameManager>().GameOver();
        }
        else
        {
            health -= damage;
        }
    }
    public void Bonus(int bonus)
    {
        if (health + bonus > 100)
            health = 100;
        else
            health += bonus;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Virus"))
        {
            Damage(virusDamage);
            FindObjectOfType<AudioManager>().Play("virusDamageSound");
        }
        if (collision.gameObject.CompareTag("FakeNews"))
        {
            Damage(fakeNewsDamage);
            FindObjectOfType<AudioManager>().Play("damageSound");
        }
        if (collision.gameObject.CompareTag("BlueGloves"))
        { 
            Bonus(blueGlovesBonus);
            FindObjectOfType<AudioManager>().Play("bonusSound");
        }
        if (collision.gameObject.CompareTag("WhiteGloves"))
        {
            Bonus(whiteGlovesBonus);
            FindObjectOfType<AudioManager>().Play("bonusSound");
        }
        if (collision.gameObject.CompareTag("Mask"))
        {
            Bonus(maskBonus);
            FindObjectOfType<AudioManager>().Play("bonusSound");
        }

        healthBar.SetValue(health);
    }
    
}
