using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentItems : BaseInteractable
{
    public GameObject ItemPrefab;
    public GameObject PickupUI;

    private void Start()
    {
        ActivateUI(false);

        GameObject itemObject = Instantiate(ItemPrefab, transform.position, Quaternion.identity);
        itemObject.transform.parent = transform;

        Name = ItemPrefab.name;

        gameObject.name = $"{gameObject.name} - {ItemPrefab.name}";
    }

    public override void Interact(GameObject Player)
    {
        base.Interact(Player);

        transform.parent = Player.transform;
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        ActivateUI(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            ActivateUI(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            ActivateUI(false);
    }

    private void ActivateUI(bool value)
    {
        if (!PickupUI) return;

        PickupUI.SetActive(value);
    }








}
