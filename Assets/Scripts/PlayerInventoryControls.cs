using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryControls : MonoBehaviour
{
    private uint _woodCount;
    private uint _stoneCount;
    private uint _clayCount;

    public uint WoodCount
    {
        get => _woodCount;
        set
        {
            _woodCount = value;
            Debug.Log($"New Wood Count: {_woodCount}");
        }
    }

    public uint StoneCount
    {
        get => _stoneCount;
        set
        {
            _stoneCount = value;
            Debug.Log($"New Stone Count: {_stoneCount}");
        }
    }

    public uint ClayCount
    {
        get => _clayCount;
        set
        {
            _clayCount = value;
            Debug.Log($"New Clay Count: {_woodCount}");
        }
    }

    public void Start()
    {
        WoodCount = 0;
        StoneCount = 0;
        ClayCount = 0;
    }
}
