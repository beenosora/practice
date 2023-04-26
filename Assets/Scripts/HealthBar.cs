using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Image healthBarSprite;

    // Update is called once per frame
 public void UpdateHealthBar(float maxHealth,float currentHealth)
    {
        healthBarSprite.fillAmount = currentHealth / maxHealth;
    }
}
