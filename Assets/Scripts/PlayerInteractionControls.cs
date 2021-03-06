using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerInventoryControls))]
public class PlayerInteractionControls : MonoBehaviour
{
    [SerializeField]
    private GameObject ShovelUIElement;

    [SerializeField]
    private GameObject PickaxeUIElement;

    [SerializeField]
    private GameObject AxeUIElement;

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

            PickaxeUIElement.SetActive(_currentlySelectedTool.Id == 1);
            ShovelUIElement.SetActive(_currentlySelectedTool.Id == 2);
            AxeUIElement.SetActive(_currentlySelectedTool.Id == 3);
        }
    }

    private Animator Animator;
    private PlayerInventoryControls PlayerInventoryControls;


    public void Start()
    {
        Animator = GetComponent<Animator>();
        PlayerInventoryControls = GetComponent<PlayerInventoryControls>();

        CurrentlySelectedTool = new Axe();
    }

    public void OnSelectNextTool()
    {
        CurrentlySelectedTool = CurrentlySelectedTool.NextTool();
    }

    public void OnSelectPreviousTool()
    {
        CurrentlySelectedTool = CurrentlySelectedTool.PreviousTool();
    }

    public void OnChangeAge()
    {
        Animator.SetBool("IsAdult", !Animator.GetBool("IsAdult"));
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