using System;
using UnityEngine;

public class Painting : Catchable
{
    public int id; 

    protected override void Start()
    {
        base.Start();
        gameObject.tag = "Painting";
        //gameObject.SetActive(false);
    }

    protected override void OnTriggerStay(Collider other)
    {
        base.OnTriggerStay(other);

        if (done)
            return;
    }

    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);

    }

    void Update()
    {
        if (done)
            return;

        if (triggered)
        {
            transform.position = camPlayer.position + (camPlayer.forward * 3.5f);
            transform.rotation = camPlayer.rotation;
            transform.rotation = Quaternion.LookRotation(-transform.forward, Vector3.up);
            // transform.position = camPlayer.position;
            
            if (Input.GetKeyDown(KeyCode.E) && justTriggered == false) // Au moment où triggered = true update confirme l'input ici aussi
            {
                triggered = false;
            }

            justTriggered = false;
        }
    }
}
