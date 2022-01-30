using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerInventoryControls))]
public class PlayerInteractionControls : MonoBehaviour
{
    [SerializeField]
    private float InteractionRange = 3f;

    private Tool _currentlySelectedTool;

    public Tool CurrentlySelectedTool
    {
        get => _currentlySelectedTool;
        set
        {
            _currentlySelectedTool = value;
            Animator.SetInteger("SelectedTool", _currentlySelectedTool.Id);
        }
    }

    private Animator Animator;
    private PlayerInventoryControls PlayerInventoryControls;


    public void Start()
    {
        Animator = GetComponent<Animator>();
        PlayerInventoryControls = GetComponent<PlayerInventoryControls>();

        CurrentlySelectedTool = new Pickaxe();
    }

    public void OnSelectNextTool()
    {
        CurrentlySelectedTool = CurrentlySelectedTool.NextTool();
    }

    public void OnSelectPreviousTool()
    {
        CurrentlySelectedTool = CurrentlySelectedTool.PreviousTool();
    }

    public void OnInteract()
    {
        ToolInteractionContext context = new ToolInteractionContext(
            InteractionRange, 
            transform.position, 
            PlayerInventoryControls);

        if (!CurrentlySelectedTool.TryInteract(context))
        {
            Debug.Log("No interactable Object found");
        }
    }
}