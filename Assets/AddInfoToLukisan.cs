using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddInfoToLukisan : MonoBehaviour
{
    public bool updateTulisan;
    public GameObject template;
    private void OnValidate()
    {
        if (updateTulisan)
        {
            GameObject[] obj = GameObject.FindGameObjectsWithTag("rumah");
            foreach (GameObject item in obj)
            {
                Instantiate(template, item.transform);
            }
        }
    }
}
