using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contemplation : MonoBehaviour
{
    // Script cinématique avec travelling de caméra autour des corps figés

    [SerializeField] GameObject[] Cams;
    AudioSource _audio;
    Camera PlayerCam;

    void Start()
    {
   
        _audio = GetComponent<AudioSource>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
           PlayerCam = player.GetComponentInChildren<Camera>();
        }

        Cams = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            Cams[i] = transform.GetChild(i).gameObject;
            Cams[i].SetActive(false);
        }
   

        StartCoroutine(Cinematic());
    }

   private IEnumerator Cinematic()
   {
        if(_audio != null)
        {
            _audio.Play();
        }

        if(PlayerCam != null)
            PlayerCam.enabled = false;

        foreach(GameObject cam in Cams)
        {
            Debug.Log(cam.name);
            cam.SetActive(true);
            yield return new WaitForSecondsRealtime(10);
            cam.SetActive(false);
        }
   }
}
