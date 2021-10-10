using System.Collections;
using UnityEngine;

public class DebrisGroup : MonoBehaviour
{
    public bool doorIsLocked = true;
    public Transform FriendlyStone;
    [SerializeField] GameObject Door;
    [SerializeField] GameObject Painting;
    public SkinnedMeshRenderer StatueRend;
    Color StatueColor;

    public float DebrisTriggered;
    public float Debrislength;

    bool waitForPlayer;
    public bool Complete;




    void Start()
    {
        foreach(Transform child in transform)
        {
            var script = child.gameObject.GetComponent<Debris>();
            if (script != null)
                Debrislength++;
        }

        if (StatueRend == null) return;

        StatueColor = StatueRend.material.color;
        StatueColor.a = 0;
        StatueRend.material.SetColor("_Color", StatueColor);

        // Painting.SetActive(false);
    }

    public void TriggerDebri()
    {
        DebrisTriggered++;
       /* if (StatueRend == null) return;
         StatueColor.a = DebrisTriggered / Debrislength;
        Debug.Log("Statue Load at : " +  DebrisTriggered);
        StatueRend.material.SetColor("_Color", StatueColor);
       */
        if (DebrisTriggered >= Debrislength)
        {
            // Instantiate(Painting, transform.position, Quaternion.identity);
            //Painting.SetActive(true);
            //UnlockDoor();
            Debug.Log("All Stones Triggered");
            Complete = true;        

        }
    }

    public void UnlockDoor()
    {
        Door.SetActive(false);
    }

 
}
