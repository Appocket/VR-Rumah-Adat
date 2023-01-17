using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class OnInvoke : MonoBehaviour
{
    public UnityEvent[] Aksi;

    public void InvokeEvent(int value)
    {
        Aksi[value].Invoke();
    }
}
