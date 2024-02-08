using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject MainPanel; 
    public TMP_Dropdown WeaponDropdown;
    public TMP_Dropdown InstrumentDropdown;


    private void Start()
    {
        HideUI();
    }

    public void ShowUI()
    {
        if(MainPanel)
            MainPanel.SetActive(true);
    }
    
    public void HideUI()
    {
        if(MainPanel)
            MainPanel.SetActive(false);
    }

    public bool AddItemToInstrument(string Item)
    {
        if (!InstrumentDropdown) return false;

        List<TMP_Dropdown.OptionData> optionDatas = new()
        {
            new TMP_Dropdown.OptionData(Item)
        };

        InstrumentDropdown.AddOptions(optionDatas);

        return true;
    }

























}
