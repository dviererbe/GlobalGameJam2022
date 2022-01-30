using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Tool
{
    public abstract int Id { get; }

    public abstract bool TryInteract(ToolInteractionContext context);

    public abstract Tool NextTool();

    public abstract Tool PreviousTool();

    protected bool TryFindNearestColliderWithComponent<TComponent>(
        ToolInteractionContext context,
        out TComponent component)
        where TComponent : class
    {
        var nearbyColliders = Physics2D.OverlapCircleAll(context.Position, context.InteractionRange);

        component = null;
        float nearestComponentDistance = float.PositiveInfinity;

        foreach (var collider in nearbyColliders)
        {
            if (collider.TryGetComponent<TComponent>(out var colliderComponent))
            {
                float distance = (collider.transform.position - context.Position).sqrMagnitude;

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

public class ToolInteractionContext
{
    public ToolInteractionContext(
        float interactionRange,
        Vector3 position,
        PlayerInventoryControls inventoryControls)
    {
        InteractionRange = interactionRange;
        Position = position;
        InventoryControls = inventoryControls;
    }

    public float InteractionRange { get; }
    public Vector3 Position { get; }
    public PlayerInventoryControls InventoryControls { get; }
}

public abstract class RessourceTool<TRessourceSource> : Tool where TRessourceSource : MonoBehaviour
{
    protected abstract void OnSuccess(PlayerInventoryControls inventoryControls);

    public override bool TryInteract(ToolInteractionContext context)
    {
        if (!TryFindNearestColliderWithComponent<TRessourceSource>(context, out var ressourceSource))
            return false;

        GameObject.Destroy(ressourceSource.gameObject);
        OnSuccess(context.InventoryControls);

        return true;
    }
}

public class Pickaxe : RessourceTool<Stone>
{
    public override int Id => 1;

    public override Tool NextTool() => new Shovel();

    public override Tool PreviousTool() => new Axe();

    protected override void OnSuccess(PlayerInventoryControls inventoryControls)
    {
        inventoryControls.StoneCount += 1;
    }
}

public class Shovel : RessourceTool<Clay>
{
    public override int Id => 2;

    public override Tool NextTool() => new Axe();

    public override Tool PreviousTool() => new Pickaxe();

    protected override void OnSuccess(PlayerInventoryControls inventoryControls)
    {
        inventoryControls.ClayCount += 1;
    }
}

public class Axe : RessourceTool<Tree>
{
    public override int Id => 3;

    public override Tool NextTool() => new Pickaxe();

    public override Tool PreviousTool() => new Shovel();

    protected override void OnSuccess(PlayerInventoryControls inventoryControls)
    {
        inventoryControls.WoodCount += 1;
    }
}