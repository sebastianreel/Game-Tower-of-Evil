/*
 * Keegan
 * Updated: 4/23/23
 */

using UnityEngine;
using UnityEngine.Events;

public class HealthScriptableObject : ScriptableObject
{
    public int health = 100;

    [SerializeField]
    private int maxHealth = 100;

    [System.NonSerialized]
    public UnityEvent<int> healthChangeEvent;

    private void OnEnable()
    {
        health = maxHealth;
        if (healthChangeEvent == null)
            healthChangeEvent = new UnityEvent<int>();
    }

    public void DecreaseHealth(int amount)
    {
        health -= amount;
        healthChangeEvent.Invoke(health);
    }
}

