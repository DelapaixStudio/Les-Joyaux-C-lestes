using UnityEngine;
using System.Collections;

public class SoclePierreModulable : MonoBehaviour
{
    bool done;

    private void OnTriggerEnter(Collider other)
    {            Debug.Log("OntriggerEnterSocle");

        if (other.CompareTag("PierreModulable") && !done)
        {
            StartCoroutine(Trigger(other));
            done = true;
        }
    }

    private IEnumerator Trigger(Collider pierre)
    {
        pierre.transform.position = transform.position;
        pierre.transform.rotation = transform.rotation;
        Animator anim = pierre.gameObject.GetComponent<Animator>();
        anim.SetBool("Triggered", true);
        anim.SetBool("Catched", false);

        PierreModulable script = pierre.gameObject.GetComponent<PierreModulable>();
        script.triggered = false;
        yield return new WaitForEndOfFrame();
        pierre.GetComponent<BoxCollider>().isTrigger = false;
        Destroy(pierre.GetComponent<PierreModulable>());
    }


}
