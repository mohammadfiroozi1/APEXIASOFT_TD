using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class TowerIcon : MonoBehaviour
{
    [SerializeField] Image iconImage;
    [SerializeField] TextMeshProUGUI priceText;
    [SerializeField] TextMeshProUGUI towerName;
    [SerializeField] Button buildButton;
    [SerializeField] TowerBuilderPannelChannel towerBuilderEventChannel;
    Toweres tower;
    Transform towerPosition;
    int price;


    private void Start()
    {
        buildButton.onClick.AddListener(BuildTower); 
    }
    public void Initialize(Toweres tower,Transform towerPosition)
    {
        this.tower = tower;
        this.towerPosition = towerPosition;

        iconImage.sprite = tower.data.towerIcon;
        priceText.text = tower.data.price.ToString();
        this.price = tower.data.price;
        towerName.text = tower.data.towerName;
    }



    private void BuildTower()
    {
        Instantiate(tower, towerPosition.position, Quaternion.identity);
        towerBuilderEventChannel.GetValue().ClosePanel();
        Destroy(towerPosition.gameObject);
    }
}
