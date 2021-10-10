using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class LittleStone : MonoBehaviour
{

    GameObject Player;
    [SerializeField] GameObject InteractUI;
    RaycastHit hit;
    [SerializeField] GameObject CinematicCams;
    bool done;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject; // On récupère la caméra.
    }

    void Update()
    {
        if (Player == null || done)
            return;

        int layerMask = LayerMask.GetMask("Interact");
        float rayLength = 20;

        if(Vector3.Distance( Player.transform.position, transform.position ) < 5)
        {
            // Attention à collider trigger ou layermask non trouvé
            Debug.DrawRay(Player.transform.position, Player.transform.forward * rayLength, Color.yellow);
            if (Physics.Raycast(Player.transform.position, Player.transform.forward, out hit, rayLength, layerMask))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Activation cinématique pierre
                    CinematicCams.SetActive(true);
                    done = true;
                }
            }
        }
    }
}
