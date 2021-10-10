using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;

public class ForgiveGroupTrigger : MonoBehaviour
{
    AudioSource _audio;
    Camera cam;
    GameObject Player;
    void Start()
    {
       _audio = GetComponent<AudioSource>();
        cam = GetComponentInChildren<Camera>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player = other.gameObject;
            StartCoroutine(Cine());
        }
    }

    private IEnumerator Cine()
    {
        _audio.Play();
        Player.SetActive(false);
        cam.gameObject.SetActive(true);
        while (_audio.isPlaying)
        {
            yield return new WaitForEndOfFrame();
        }
        cam.gameObject.SetActive(false);
        Player.SetActive(true);

    }

    
}
