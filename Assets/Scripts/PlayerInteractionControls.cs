using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionControls : MonoBehaviour
{
    [SerializeField]
    private float InteractionRadius = 3f;

    public void OnInteract()
    {
        if (TryFindNearestComponent<IInteractable>(out var interactableObject, InteractionRadius))
        {
            interactableObject.Interact();
        }
    }

    private bool TryFindNearestComponent<TComponent>(out TComponent component, float radius) where TComponent : class
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        component = null;
        float nearestComponentDistance = float.PositiveInfinity;

        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent<TComponent>(out var colliderComponent))
            {
                float distance = (collider.transform.position - transform.position).sqrMagnitude;

                if (distance < nearestComponentDistance)
                {
                    nearestComponentDistance = distance;
                    component = colliderComponent;
                }
            }
        }

        return component != null;
    }
}

public interface IInteractable
{
    public void Interact();
}
