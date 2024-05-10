using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

internal static class DetectOculus
{
    public static bool isPresent()
    {
        var xrDisplaySubsystems = new List<XRDisplaySubsystem>();
        SubsystemManager.GetInstances<XRDisplaySubsystem>(xrDisplaySubsystems);
        foreach (var xrDisplay in xrDisplaySubsystems)
        {
            if (xrDisplay.running)
            {
                return true;
            }
        }
        return false;
    }
}
public class CheckXRDisplay : MonoBehaviour
{
    public bool Awake()
    {
        Debug.Log("Hay un oculus conectado? :"+DetectOculus.isPresent().ToString());
        return DetectOculus.isPresent();
    }
}