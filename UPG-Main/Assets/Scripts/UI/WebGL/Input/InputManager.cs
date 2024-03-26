using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public delegate void EnvironmentChange(EnvironmentBackgroundData backgroundData);
    public static event EnvironmentChange onEnvironmentChange;

    public EnvironmentBackgroundData[] backgroundData;

    InputControls inputs;

    int i = 0;

    private void OnEnable()
    {
        inputs.Enable();
        
    }

    private void OnDisable()
    {
        inputs.Disable();
    }

    public void Awake()
    {
        inputs = new InputControls();

        inputs.DesktopControls.NextAreaTest.started += ctx => Clicked(ctx);
        inputs.DesktopControls.Notification.performed += ctx => Notif(ctx);
    }

    private void Start()
    {
        onEnvironmentChange.Invoke(backgroundData[0]);
        //get name or give error
        name = "TestName";
        //name = activePlayer.name;
        //activePlayer = player with name (activePlayer.name)
        if (name == null)
        {
            NotificationManager.Instance.SetNewNotification("Error");
        }

    }

    private void Clicked(InputAction.CallbackContext context)
    {
        if(i < backgroundData.Length - 1)
        {
            i++;
            onEnvironmentChange.Invoke(backgroundData[i]);
        }
        else
        {
            i = 0;
            onEnvironmentChange.Invoke(backgroundData[0]);
        }
    }
    
    private void Notif(InputAction.CallbackContext context)
    {
        NotificationManager.Instance.SetNewNotification($"{name}'s Turn");
    }

}
