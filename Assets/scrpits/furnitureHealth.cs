using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class furnitureHealth : MonoBehaviour
{
    [SerializeField] private Image healtbarSprite;
    int currentHealth;
    int maxHealth = 100;

    public Vector3 offset = new Vector3(0f, 1f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        SetHealth(currentHealth, maxHealth);
    }
   

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        SetHealth(currentHealth, maxHealth);
        if (currentHealth <= 0)
        {
            Debug.Log("mobilya kullanýlamaz halde");
        }
    }

    public void SetHealth(float health, float maxHealth)
    {
        healtbarSprite.fillAmount = currentHealth / maxHealth;
    }
}
