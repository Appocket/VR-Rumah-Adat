using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LukisanCreator : MonoBehaviour
{
    public int startIndex = 0;
    public LukisanItem template;
    public bool Update = false;

    private void OnValidate()
    {
        if (Update)
        {
            UpdateList();
        }
    }
    public void UpdateList()
    {
        if (template != null)
        {
            for (int i = 0; i < 13; i++)
            {
                if (transform.childCount > 0)
                {
                    foreach (Transform item in transform.GetChild(i))
                    {
#if UNITY_EDITOR
                        UnityEditor.EditorApplication.delayCall += () =>
                        {
                            DestroyImmediate(item.gameObject);
                        };
#endif
                    }
                }
                if (i + startIndex < template.databaseRumah.Data.Count)
                {
                    var lukisanBaru = Instantiate(template.gameObject, transform.GetChild(i));
                    lukisanBaru.GetComponent<LukisanItem>().index = startIndex + i;
                    lukisanBaru.transform.localPosition = new Vector3(0, 0, 0);
                    lukisanBaru.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    lukisanBaru.GetComponent<LukisanItem>().updateGambar();
                    lukisanBaru.name = "Lukisan " + (startIndex + i);
                    lukisanBaru.SetActive(true);
                }
            }
        }
    }
}
