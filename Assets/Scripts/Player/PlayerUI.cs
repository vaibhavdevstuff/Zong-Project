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

    public bool UpdateItemToInstrument(List<GameObject> objectToAdd)
    {
        if (!InstrumentDropdown) return false;

        InstrumentDropdown.ClearOptions();

        List<TMP_Dropdown.OptionData> optionDataList = new();

        if(objectToAdd.Count > 0)
        {
            foreach(GameObject obj in objectToAdd)
            {
                string iteamName = obj.GetComponent<InstrumentItems>().Name;

                TMP_Dropdown.OptionData optionData = new(iteamName);

                optionDataList.Add(optionData);
            }

            InstrumentDropdown.AddOptions(optionDataList);
        }

        return true;
    }






}
