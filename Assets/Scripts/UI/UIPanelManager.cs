using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelManager : MonoBehaviour
{
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] GameObject statsPanel;
    [SerializeField] GameObject questPanel;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            OpenInventory();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            OpenStatsPanel();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            OpenQuestPanel();
        }
    }

    public void OpenInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeInHierarchy);
    }

    public void OpenStatsPanel()
    {
        statsPanel.SetActive(!statsPanel.activeInHierarchy);
        questPanel.SetActive(false);
    }

    public void OpenQuestPanel()
    {
        questPanel.SetActive(!questPanel.activeInHierarchy);
        statsPanel.SetActive(false);
    }
}
