using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryControls : MonoBehaviour
{
    private uint WoodCount;
    private uint StoneCount;
    private uint ClayCount;

    public void Start()
    {
        WoodCount = 0;
        StoneCount = 0;
        ClayCount = 0;
    }
}
