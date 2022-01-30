using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourcenController : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    void Start()
    {
        if (!TryGetComponent<Collider2D>(out _))
        {
            Debug.LogError("Ressource Object has no Collider. It can't be detected!");
        }
    }

    public void Interact()
    {
        Debug.Log("Interacted with Resource Object");
    }
}
