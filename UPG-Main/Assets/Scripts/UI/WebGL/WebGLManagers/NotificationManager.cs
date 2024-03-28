using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class NotificationManager : MonoBehaviour
{
    private static NotificationManager instance;

    [SerializeField] private TextMeshProUGUI notificationText;
    [SerializeField] private float fadeTime;

    private IEnumerator notificationCoroutine;

    public RectTransform notification;


    /// <summary>
    /// check if instance is not empty, then return it.
    /// </summary>
    public static NotificationManager Instance {
        get
        {
            if (instance != null)
            {
                return instance;
            }
            instance = FindAnyObjectByType<NotificationManager>();            
            return instance;
        }
    }

    /// <summary>
    /// set text and animate it
    /// </summary>

    public void SetNewNotification(string message)
    { 
        if (notificationCoroutine != null)
        {
            StopCoroutine(notificationCoroutine);
        }
        notification.DOAnchorPos(new Vector3(0, -115, 0), 0.5f);
        StartCoroutine(OutNotification(message));
    }
    private IEnumerator OutNotification(string message)
    {
        notificationText.text = message;
        float t = 0;
        while (t < fadeTime)
        {
            t += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        notification.DOAnchorPos(new Vector3(0, 165, 0), 0.5f);
    }

}