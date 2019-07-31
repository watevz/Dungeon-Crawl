using UnityEngine;

public class CharacterStats : MonoBehaviour {

    public int maxHealth = 100;
    public int currentHealth; //{ get; set; }

    public Stat damage;
    public Stat armour;
    public Stat attackRange;

    void Awake()
    {
        currentHealth = maxHealth;
    }

}
