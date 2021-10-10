using UnityEngine;

public class PierreModulable : Catchable
{
    Animator _anim;

    protected override void Start()
    {
        base.Start();
        _anim = GetComponent<Animator>();
    }


    protected override void OnTriggerStay(Collider other)
    {
        base.OnTriggerStay(other);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Impulsion") && !triggered)
        {
            _anim.SetBool("Triggered", true);
        }
    }


    void Update()
    {
        if (justTriggered)
        {
            _anim.SetBool("Catched", true);
            _anim.SetBool("Triggered", false);
          
        }

        if (triggered)
        {
            transform.position = camPlayer.position + (camPlayer.forward * 2f);
            transform.rotation = camPlayer.rotation;
            transform.rotation = Quaternion.LookRotation(-transform.forward, Vector3.up);

            justTriggered = false;
        }
    }
}
