using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//keeps track of the currently active environment
public enum CurrentActiveEnv
{
    plains,
    jungle,
    desert,
    mountain
}

public class Gamemanager : MonoBehaviour
{
    //enum that shows the current active area
    public CurrentActiveEnv currentActiveEnv;

    public GameObject[] LayoutImages;


    private void OnEnable() 
    {
        InputManager.onEnvironmentChange += SetCurrentEnvColor;
    }
    
    private void OnDisable()
    {
        InputManager.onEnvironmentChange -= SetCurrentEnvColor;
    }

    //sets the colors of the background
    private void SetCurrentEnvColor(EnvironmentBackgroundData backgroundData)
    {
        //sets the current environment enum to the given one
        currentActiveEnv = backgroundData.currentEnv;

        //make sure the layout images have been set. yes I know this is shit but its simple so why complicate
        if (LayoutImages != null)
        {
            LayoutImages[0].GetComponent<Image>().color = backgroundData.primaryColor;
            LayoutImages[1].GetComponent<Image>().color = backgroundData.secondaryColor;
            LayoutImages[2].GetComponent<Image>().color = backgroundData.secondaryColor;

            //add the proper screen decoration to the specific environment
            LayoutImages[3].GetComponent<Image>().sprite = backgroundData.screenDecorations;
            LayoutImages[3].GetComponent<Image>().preserveAspect = true;
        }
    }
}
