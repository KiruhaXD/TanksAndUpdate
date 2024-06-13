using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateTanks : MonoBehaviour
{
    public TMP_Text healthText;
    public int _health;

    public TMP_Text armorText;
    public int _armor;

    public TMP_Text powerText;
    public int _power;

    [SerializeField] private TankModifier tankModifier;

    public void UpdateCharacteristicsTanksHealth() 
    {
        tankModifier.health += _health;
        tankModifier.UpdateUIHealth();
    }

    public void UpdateCharacteristicsTanksArmor() 
    {
        tankModifier.armor += _armor;
        tankModifier.UpdateUIArmor();
    }

    public void UpdateCharacteristicsTanksPower()
    {
        tankModifier.power += _power;
        tankModifier.UpdateUIPower();
    }

    
}
