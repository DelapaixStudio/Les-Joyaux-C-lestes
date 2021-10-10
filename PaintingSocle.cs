using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingSocle : MonoBehaviour
{

    GameObject painting;
    Transform paintingPos; // Créer un GO de position pour l'image
    [SerializeField] int id;
    bool unlock;


    void Start()
    {
        paintingPos = transform.GetChild(0);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Painting") && unlock == false)
        {
            painting = other.gameObject;
            var script = painting.GetComponent<Painting>();
            script.triggered = false;
            if(script.id == id)
            {
                Debug.Log("Socle Activé");
                script.done = true;
                script.enabled = false;
                painting.transform.position = paintingPos.position;
                painting.transform.rotation = paintingPos.rotation;
                painting.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                unlock = true;
                Unlock();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Painting"))
        {
            painting = null;   
        }
    }

    private void Unlock()
    {
        transform.parent.gameObject.GetComponent<SocleGroup>().Check();
    }

    void Update()
    {
        if(painting != null)
        {
            painting.transform.position = paintingPos.position;
        }
    }
}
