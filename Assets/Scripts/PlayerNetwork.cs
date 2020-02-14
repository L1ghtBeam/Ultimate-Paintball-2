using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetwork : NetworkBehaviour
{
    [SyncVar]
    int health;

    [SerializeField]
    int maxHealth = 1000;

    private void Awake()
    {
        SetDefaults();
    }

    void SetDefaults()
    {
        health = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        Debug.Log(transform.name + " now has " + health + " health!");
    }

}
