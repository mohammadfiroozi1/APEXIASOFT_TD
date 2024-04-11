using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerBuilder : MonoBehaviour
{

    [SerializeField] TowerBuilderPannelChannel towerUiPanel;
    [SerializeField] List<Toweres> toweresList = new List<Toweres>();

    private void OnMouseDown()
    {
        towerUiPanel.GetValue().ShowTowerPanel(transform, toweresList);
    }
    


}
