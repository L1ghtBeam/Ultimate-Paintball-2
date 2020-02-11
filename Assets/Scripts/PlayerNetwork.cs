using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetwork : NetworkBehaviour
{
    [SyncVar]
    int health;

    [SerializeField]
    int maxHealth = 100;

    private void Awake()
    {
        SetDefaults();
    }

    void SetDefaults()
    {
        health = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= maxHealth;

        Debug.Log(transform.name + " now has " + health + " health!");
    }

}
