using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    
    public HealthBar healthBar;

    [Header("Damage Overlay")]
    public Image damageOvelay;
    public float fadeSpeed;
    public float duration;
    private float durationTimer;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        damageOvelay.color = new Color(damageOvelay.color.r, damageOvelay.color.g, damageOvelay.color.b, 0);

    }

<<<<<<< Updated upstream
    // Update is called once per frame
    void Update()
    {
        if(damageOvelay.color.a > 0)
        {
            durationTimer += Time.deltaTime;
            if (durationTimer > duration)
            {
                // fade image
                float tempAlpha = damageOvelay.color.a;
                tempAlpha -= Time.deltaTime * fadeSpeed;

                damageOvelay.color = new Color(damageOvelay.color.r, damageOvelay.color.g, damageOvelay.color.b, tempAlpha);
            }
        }
    }

=======
>>>>>>> Stashed changes
    public void TakeDamage(int damage){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0){
            SceneManager.LoadScene("MainMenu");
        }
<<<<<<< Updated upstream

        durationTimer = 0;
        damageOvelay.color = new Color(damageOvelay.color.r, damageOvelay.color.g, damageOvelay.color.b, 1);
=======
        Debug.Log("Player takes: " + damage);
>>>>>>> Stashed changes
    }


}
