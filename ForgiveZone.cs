
using UnityEngine;

public class ForgiveZone : MonoBehaviour
{

    [SerializeField] GameObject forgiveScreen;
    [SerializeField] GameObject humansGroup;

    GameObject ccPlayer;

    bool trigger;

    private void Start()
    {
        ccPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (trigger == false && other.CompareTag("Player"))
        {
            forgiveScreen.SetActive(true);
            ccPlayer.SetActive(false);
            trigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            trigger = false;
        }
    }



    private void HideScreen()
    {
          forgiveScreen.SetActive(false);
        ccPlayer.SetActive(true);

    }

    public void Confirm()
    {
        HideScreen();

        if(humansGroup != null)
            Destroy(humansGroup);

        if(forgiveScreen != null)
            Destroy(forgiveScreen);

        Destroy(gameObject);
    }

    public void Refuse()
    {
        Debug.Log("HideScreen");
        HideScreen();
    }
}
