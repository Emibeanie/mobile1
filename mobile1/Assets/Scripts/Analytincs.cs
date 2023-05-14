using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;
using System;
using UnityEngine.SceneManagement;


public class Analytincs : MonoBehaviour
{
    [ContextMenu("Initialiaze UGS")]
   async void InitalizeUGS()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("First");
        await UnityServices.InitializeAsync();
        Debug.Log("Second");
        List<string> consentIdentifiers = await AnalyticsService.Instance.CheckForRequiredConsents();
        try
        {
            if (consentIdentifiers.Count > 0)
            {
                foreach (string consentIdentifier in consentIdentifiers)
                {
                    Debug.Log(consentIdentifier);
                }
            }
            else
            {
                Debug.Log("No need for consent for analytics");
            }
        }
        catch (ConsentCheckException exception)
        {
            Debug.LogError("Exeption with checking constents!" + Environment.NewLine + exception.Message );
        }
    }
}
