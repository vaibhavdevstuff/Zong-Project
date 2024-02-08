using System;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentItemHandler : MonoBehaviour
{

    public LayerMask itemLayer;

    public GameObject detectedItem;
    public List<GameObject> instrumentItems = new List<GameObject>();

    private PlayerUI playerUI;

    private void Start()
    {
        playerUI = GetComponentInChildren<PlayerUI>();
    }

    private void Update()
    {
        InteractWithItem();
    } 

    private void InteractWithItem()
    {
        if (Input.GetKeyDown(KeyCode.E) && detectedItem)
        {
            var item = detectedItem.GetComponent<BaseInteractable>();

            if (item)
            {
                instrumentItems.Add(detectedItem);
                
                item.Interact(gameObject);

                if (playerUI)
                {
                    playerUI.ShowUI();
                    playerUI.AddItemToInstrument(item.Name);
                }

                detectedItem = null;
            }

        }
    }

    public bool HaveItems()
    {
        return instrumentItems.Count > 0;
    }    

    public GameObject GetInstrumentItem()
    {
        if(instrumentItems.Count == 0) return null;

        GameObject item = instrumentItems[0];

        instrumentItems.RemoveAt(0);

        return item;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(itemLayer == (itemLayer | (1 << other.gameObject.layer)))
        {
            detectedItem = other.gameObject;          

        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if(itemLayer == (itemLayer | (1 << other.gameObject.layer)) && detectedItem == other.gameObject)
        {
            detectedItem = null;          

        }
    }











}
