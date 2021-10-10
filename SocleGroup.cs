using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocleGroup : MonoBehaviour
{

    [SerializeField] GameObject Door;
    int unlockedSocles;
    int socles;

    void Start()
    {
        //socles = transform.childCount;
        foreach(Transform child in transform)
        {
            if (child.gameObject.activeSelf)
                socles++;
        }
   
        Debug.Log("Il y a " + socles + "scoles");
    }

    public void Check()
    {
        unlockedSocles++;
        if(unlockedSocles >= socles)
        {
            Door.SetActive(false);
        }
    }

}
