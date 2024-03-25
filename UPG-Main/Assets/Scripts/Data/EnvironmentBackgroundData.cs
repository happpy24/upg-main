using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BackgroundColorData", order = 1)]
public class EnvironmentBackgroundData : ScriptableObject
{
    //colors to be assigned to the background sprites of the canvas

    //primary color to be used as main background
    public Color primaryColor;
    
    //secondary used as name bar and deck background
    public Color secondaryColor;

    //tertiary used as shadow color under specifick bars
    public Color tertiaryColor;

    public Sprite screenDecorations;

    [Header("Area Enum")]
    public CurrentActiveEnv currentEnv;
}
