using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class RestoreButton : MonoBehaviour
{
    public void Restore()
    {
        var apple = CodelessIAPStoreListener.Instance.GetStoreExtensions<IAppleExtensions>();
        apple.RestoreTransactions((result) => {
            Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
        });
    }
}
