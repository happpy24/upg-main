using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LobbyManager : MonoBehaviour
{
    public void CallRegister() => StartCoroutine(Register());

    IEnumerator Register()
    {
        UnityWebRequest dbCode = new UnityWebRequest("");
        yield return dbCode;
        Debug.Log(dbCode.ToString());
    }
}
