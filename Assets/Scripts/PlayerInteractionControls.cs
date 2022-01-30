using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovementControls))]
public class PlayerInteractionControls : MonoBehaviour
{
    [SerializeField]
    private float InteractionRange = 3f;

    [SerializeField]
    private float InteractionWidth = 3f;

    private PlayerMovementControls movementControls;

    public GameObject obj;

    public void Start()
    {
        movementControls = GetComponent<PlayerMovementControls>();
    }

    public void OnInteract()
    {
        //if (movementControls.CurrectVelocity > 0.01f)
        //{
        //    return;
        //}

        if (TryFindNearestInteractableObject(out var interactableObject, InteractionRange))
        {
            interactableObject.Interact();
        }
        else
        {
            Debug.Log("False!");
        }
    }

    private bool TryFindNearestInteractableObject(out IInteractable interactableObject, float range)
    {
        var position = (Vector2)transform.position;
        var direction = movementControls.CurrectDirection;

        var point = position + (direction * (InteractionRange / 2) - direction * 0.1f);
        var size = new Vector2(InteractionWidth, InteractionRange);
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //obj.transform.position = point;
        //obj.transform.SetPositionAndRotation(position, Quaternion.Euler(0, 0, angle));
        //obj.transform.localScale = size;

        var colliders = Physics2D.OverlapBoxAll(point, size, angle);
        return TryGetNearastComponent(colliders, out interactableObject);
    }

    private bool TryGetNearastComponent<TComponent>(Collider2D[] colliders, out TComponent component) where TComponent : class
    {
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
