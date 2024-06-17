using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour{
    private int currHealth;
    private int maxHealth;
    private int gold;
    private int level;
    private int xp;

    public int CurrHealth {
        get => currHealth;
        set => currHealth = value;
    }

    public int MaxHealth {
        get => maxHealth;
        set => maxHealth = value;
    }

    public int Gold {
        get => gold;
        set => gold = value;
    }

    public int Level {
        get => level;
        set => level = value;
    }

    public int Xp {
        get => xp;
        set => xp = value;
    }

    public void TakeDamage(int damage = 0) {
        currHealth -= damage;
        if (currHealth <= 0) {
            Time.timeScale = 0;
            Destroy(this);
        }
    }
}
