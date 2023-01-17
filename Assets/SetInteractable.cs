using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetInteractable : MonoBehaviour
{
    public void Interactable(bool value)
    {
        foreach (Transform item in transform)
        {
            item.GetComponent<Button>().interactable = value;
            item.GetComponent<GazeButton>().interactable = value;
        }
    }

    public void SetButtonInteractable(int value)
    {
        foreach (Transform item in transform)
        {
            item.GetComponent<Button>().interactable = false;
        }
        transform.GetChild(value).GetComponent<Button>().interactable = true;
    }
}
