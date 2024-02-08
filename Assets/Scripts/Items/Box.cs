using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : BaseInteractable
{
    public bool ResetToCheckpoint = false;

    public Transform ItemHolder;
    public ParticleSystem AuraParticle;

    public GameObject InteractUI;

    private GameObject instrumentItem;

    private void Start()
    {
        ActivateUI(false);
    }

    private void OnDisable()
    {
        ActivateUI(false);
    }

    public override void Interact(GameObject Player)
    {
        InstrumentItemHandler instrumentItemHandler = Player.GetComponent<InstrumentItemHandler>();


        if (!instrumentItemHandler.HaveItems()) return;

        if (ResetToCheckpoint)
        {
            ActivateUI(false);
            CheckpointManager.Instance.GotoPreviousCheckpoint(Player);
            return;
        }

        instrumentItem = instrumentItemHandler.GetInstrumentItem();

        instrumentItem.SetActive(true);
        instrumentItem.transform.parent = ItemHolder.transform;
        instrumentItem.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);

        instrumentItem.GetComponent<BaseInteractable>().OnInteract += OnItemGetInteract;

        AuraParticle.Play();

        ActivateUI(false);
    }

    private void OnItemGetInteract()
    {
        instrumentItem.GetComponent<BaseInteractable>().OnInteract -= OnItemGetInteract;

        AuraParticle.Stop();

        ActivateUI(true);

        instrumentItem = null;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!instrumentItem) ActivateUI(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ActivateUI(false);
        }
    }

    private void ActivateUI(bool value)
    {
        if (!InteractUI) return;

        InteractUI.SetActive(value);
    }









}
