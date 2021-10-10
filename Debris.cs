using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour
{

    DebrisGroup groupScript;
    [SerializeField] GameObject PrefabDebri;
    [SerializeField] Transform[] Pieces;

    Vector3 posMainStone;
    bool done;
    bool wait;

    LineRenderer lineRend;


    void Start()
    {
        //posMainStone = transform.parent.position;
       // posMainStone = transform.parent.GetComponent<DebrisGroup>().StatueRend.transform.position;
        lineRend = gameObject.GetComponent<LineRenderer>();
        if(lineRend != null)
            lineRend.enabled = false;
        groupScript = transform.parent.GetComponent<DebrisGroup>();
    }

    private void OnTriggerEnter(Collider other)
    {     
        if (other.CompareTag("Impulsion") && done == false)
        {
            StartCoroutine(GoToMainStone());
            done = true;
        }
    }

    private IEnumerator GoToMainStone()
    {

        GameObject fils = transform.GetChild(0).gameObject; // Activation particules
        if(fils != null)
        {
            fils.SetActive(true);
        }

        Destroy(gameObject.GetComponent<Rigidbody>());
        lineRend.enabled = true;


        // Le débri se lève
        float _time = 0f;
        int timer = 3;     
        Vector3 posDebri = transform.position;
        Vector3 pos = posDebri + (transform.up * 3);
        Debug.Log("Go Up");

        while (_time < timer)
        {
            transform.position = Vector3.Lerp(posDebri, pos, _time/timer);
       //     Debug.Log("temps / timer = " +_time / timer);
       //     Debug.Log("temps = " + _time );

            _time += + Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        transform.parent.gameObject.GetComponent<DebrisGroup>().TriggerDebri(); // Comptabilise le nombre de débris activés.
        wait = true;
        while (groupScript.Complete == false) { yield return new WaitForEndOfFrame(); }

        // Le débri s'envole vers la pierre principale
        _time = 0f;
        timer = 2; 
        posDebri = transform.position;
        Debug.Log("Go To Final Pos");

        while (_time < timer)
        {
            transform.position = Vector3.Lerp(posDebri, groupScript.FriendlyStone.position, _time / timer);
            _time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        Destroy(gameObject);

        
    }


}
