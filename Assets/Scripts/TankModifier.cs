using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TankModifier : MonoBehaviour
{
    [SerializeField] private TMP_Text healthText;
    public int health = 100;

    [SerializeField] private TMP_Text armorText;
    public int armor = 20;

    [SerializeField] private TMP_Text powerText;
    public int power = 20;

    public void TakeDamage(int damageCount) 
    {
        if (armor > 0)
        {
            armor -= damageCount;
            armorText.text = armor.ToString();
        }
        else 
        {
            health -= damageCount;
            if (health <= 0) 
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            healthText.text = health.ToString();
        }
    }

    public void AddHealth(int value) 
    {
        health += value;
        healthText.text = health.ToString();
    }

    public void RemoveHealth(int value) 
    {
        health -= value;      
        healthText.text = health.ToString();
    }

    public void AddArmor(int value) 
    {
        armor += value;
        armorText.text = armor.ToString();
    }

    public void RemoveArmor(int value)
    {
        armor -= value;
        armorText.text = armor.ToString();
    }

    public void AddPower(int value)
    {
        power += value;
        powerText.text = power.ToString();
    }

    public void RemovePower(int value)
    {
        power -= value;
        powerText.text = power.ToString();
    }
}
