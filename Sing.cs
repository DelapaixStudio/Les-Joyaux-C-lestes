using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sing : MonoBehaviour
{
    AudioSource _audio;
    [SerializeField] GameObject FlippedSphere;

    bool wait;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }
    private IEnumerator Propagation()
    {
        yield return null;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (!_audio.isPlaying)
            {
                _audio.Play();
            }

            if(transform.localScale.x != 15)
            {
//                Debug.Log("Propagation du Son");
                transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(15, 15, 15), 1f *  Time.deltaTime);
                //transform.localScale = transform.localScale * Time.deltaTime;

            }
        }
        else
        {
            if (_audio.isPlaying)
            {
                _audio.Stop();
            }

            transform.localScale = Vector3.zero;
        }
    }
}
