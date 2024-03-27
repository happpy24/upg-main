using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JavascriptHook : MonoBehaviour
{
    public InitPlayer initplayer;

    public void GetName(string str)
    {
        initplayer.NameChanger(str);
    }
}
