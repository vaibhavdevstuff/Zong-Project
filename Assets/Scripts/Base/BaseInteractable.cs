using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInteractable : MonoBehaviour
{
    [HideInInspector] public string Name;

    public virtual void Interact(GameObject interactingGbject) 
    {
        OnInteract?.Invoke();
    }


    public Action OnInteract;






}
