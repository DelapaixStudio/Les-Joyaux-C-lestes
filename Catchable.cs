using UnityEngine;

public class Catchable : MonoBehaviour
{
    public GameObject interactUI;

    [HideInInspector]
    public RaycastHit hit;
    [HideInInspector]
    public GameObject Player;
    [HideInInspector] 
    public Transform camPlayer;
    [HideInInspector] 
    public bool triggered;
    [HideInInspector] 
    public bool done;
    [HideInInspector] 
    public bool justTriggered;

    protected virtual void Start()
    {
        gameObject.layer = 8; // layer "Interact"
        Player = GameObject.FindWithTag("Player");
        camPlayer = Player.transform.GetChild(0);
    }

    protected virtual void OnTriggerStay(Collider other)
    {
        if (done)
            return;

        if (other.CompareTag("Player") && triggered == false)
        {
            //    Debug.Log("Player On Trigger");
            // GameObject Player = other.gameObject;
            float rayLength = 1.5f;
            int layerMask = LayerMask.GetMask("Interact");
            Debug.DrawRay(camPlayer.position, camPlayer.forward * rayLength, Color.yellow);

            if (Physics.Raycast(camPlayer.position, camPlayer.forward, out hit, rayLength, layerMask))
            {
                interactUI.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactUI.SetActive(false);
                    triggered = true;
                    justTriggered = true;
                }
            }
            else
            {
                interactUI.SetActive(false);
            }
        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactUI.SetActive(false);
        }
    }

}
