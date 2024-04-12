using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    [SerializeField] GoldManagerEventChannel goldManagerChannel;
    [SerializeField] TextMeshProUGUI goldText;
    public int totalGold;


    private void OnEnable()
    {
        goldManagerChannel.GetValue += getThis;
    }
    GoldManager getThis() => this;
    public void DecreaseGold(int gold) 
    {        
        totalGold -= gold;
        goldText.text = totalGold.ToString();
    }
    public void IncreaseGold(int gold)
    {
        totalGold += gold;
        goldText.text = totalGold.ToString();

    }
}
