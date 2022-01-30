using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryControls : MonoBehaviour
{
    [SerializeField]
    private Text ClayCountText;

    [SerializeField]
    private Text WoodCountText;

    [SerializeField]
    private Text StoneCountText;

    private uint _woodCount;
    private uint _stoneCount;
    private uint _clayCount;

    public uint WoodCount
    {
        get => _woodCount;
        set
        {
            _woodCount = value;
            WoodCountText.text = value.ToString();
        }
    }

    public uint StoneCount
    {
        get => _stoneCount;
        set
        {
            _stoneCount = value;
            StoneCountText.text = value.ToString();
        }
    }

    public uint ClayCount
    {
        get => _clayCount;
        set
        {
            _clayCount = value;
            ClayCountText.text = value.ToString();
        }
    }

    public void Start()
    {
        WoodCount = 0;
        StoneCount = 0;
        ClayCount = 0;
    }
}
