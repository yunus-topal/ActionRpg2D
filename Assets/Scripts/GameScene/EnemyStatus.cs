using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    private int currHealth;
    private int maxHealth;
    private int level;

    public int CurrHealth {
        get => currHealth;
        set => currHealth = value;
    }

    public int MaxHealth {
        get => maxHealth;
        set => maxHealth = value;
    }

    public int Level {
        get => level;
        set => level = value;
    }

    public void TakeDamage(int damage = 0) {
        currHealth -= damage;
        if (currHealth <= 0) {
            // start dying animation in the future
            Destroy(this);
        }
    }
}
