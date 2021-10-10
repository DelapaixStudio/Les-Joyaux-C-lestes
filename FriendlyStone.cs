using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class FriendlyStone : MonoBehaviour
{
    [SerializeField] Transform[] targetPos;
    NavMeshAgent navAgent;
    [SerializeField] GameObject stoneCamera;
    AudioSource _audio;
    [SerializeField] AudioClip[] _samples;
    [SerializeField] MeshDestroy Door;
    [SerializeField] DebrisGroup[] groupDebrisScript;
    int actualgroup;

    bool waitForPlayer;
    bool firstMet;
    bool done;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        stoneCamera.SetActive(false);
        _audio = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (done) return;

        if (other.CompareTag("Player") && !firstMet)
        {
            firstMet = true;
            StartCoroutine(StoneCinematic());
        }


        if (other.CompareTag("Impulsion") && waitForPlayer)
        {
            waitForPlayer = false;          
        }
    }


    private IEnumerator StoneCinematic()
    {     
        // Déplacement vers le premier groupe de débris.

        stoneCamera.SetActive(true);
        yield return new WaitForSecondsRealtime(1);
        _audio.clip = _samples[0];
        _audio.Play();
        yield return new WaitForSecondsRealtime(3);
        navAgent.SetDestination(targetPos[0].position);
        yield return new WaitForSecondsRealtime(1);
        stoneCamera.SetActive(false);


        while (!groupDebrisScript[0].Complete)
        {   yield return new WaitForEndOfFrame();   }               
        

        // Déplacement vers le deuxième groupe de débris.
        navAgent.SetDestination(targetPos[1].position);
        while (!groupDebrisScript[1].Complete)
        {    yield return new WaitForEndOfFrame();   }
        

        // Déplacement vers le troixième groupe de débris.
        navAgent.SetDestination(targetPos[2].position);
        while (!groupDebrisScript[2].Complete)
        {   yield return new WaitForEndOfFrame();    }

        // Déplacement vers la porte avant la tour.
        navAgent.SetDestination(targetPos[3].position);

        yield return new WaitForSecondsRealtime(10);

        waitForPlayer = true;
        while (waitForPlayer)
        { yield return new WaitForEndOfFrame();     }
        stoneCamera.SetActive(true);
        yield return new WaitForSecondsRealtime(1);
        _audio.pitch = 0.5f;
        _audio.clip = _samples[1];
        _audio.Play();
        Door.DestroyThis();
        yield return new WaitForSecondsRealtime(1);
        stoneCamera.SetActive(false);
        
        
        gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
        done = true;
        //        gameObject.GetComponent<MeshDestroy>().DestroyThis();

    }


}
