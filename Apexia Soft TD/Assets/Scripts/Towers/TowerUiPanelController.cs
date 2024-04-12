using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerUiPanelController : MonoBehaviour
{
    [SerializeField] TowerIcon towerIcon;
    [SerializeField] Transform buildHolder;
    [SerializeField] Button closePanelBtn;
    [SerializeField] TowerBuilderPannelChannel towerUiChannel;
    [SerializeField] GoldManagerEventChannel goldManagerChannel;
    private void Start()
    {
        gameObject.SetActive(false);
    }

    TowerUiPanelController GetThis() => this;
    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }
    public void ShowTowerPanel(Transform buildPos, List<Toweres> toweresList)
    {
        closePanelBtn.onClick.AddListener(ClosePanel);
        gameObject.SetActive(true);
        for (int i = 0; i < toweresList.Count; i++)
        {
            TowerIcon towerIconObj = Instantiate(towerIcon, buildHolder);
            //can use pool here
            towerIconObj.Initialize(toweresList[i], buildPos);
        }
    }

    private void OnDisable()
    {
        towerUiChannel.GetValue += GetThis;
        closePanelBtn.onClick.RemoveAllListeners();
        foreach (Transform child in buildHolder)
        {
            //release from pool instead
            Destroy(child.gameObject);
        }

    }

}
