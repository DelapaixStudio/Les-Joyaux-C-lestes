using UnityEngine;
using UnityEngine.UI;

public class QuestionUI : MonoBehaviour
{

    public GameObject Statue;
    public Forgive forgive;
    public string Crime;

    [SerializeField] bool forgiveZone;
    [SerializeField] Text crimeText;
    [SerializeField] ForgiveZone zoneScript;

    private void Start()
    {
        crimeText.text = Crime;
    }

    public void Answer(bool playerForgives)
    {
        Cursor.visible = false;

        if (playerForgives)
        {
            if (!forgiveZone) {   forgive.ToForgive();   }


            if(zoneScript)
            {
                zoneScript.Confirm();
            }
                Destroy(gameObject);

        }
        else
        {
            if(!forgiveZone)
                forgive.done = false;

            if (forgiveZone)
            {
                zoneScript.Refuse();
            }
        }         
        
    }

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    private void OnDisable()
    {
        Cursor.visible = false;

    }

 
}
