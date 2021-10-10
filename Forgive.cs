using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Forgive : Catchable
{

    [SerializeField] GameObject UiQuestion;
    GameObject instantiatedUI;
    FirstPersonController scriptPlayer;
    QuestionUI scriptUI;

    protected override void Start()
    {
        base.Start();
    }

    public void ToForgive()
    {
        scriptPlayer.enabled = true;
        Destroy(gameObject);
    }


    void Update()
    {
        if (triggered)
        {
            if (justTriggered)
            {
                Debug.Log("JustriggeredStatue");
                interactUI.SetActive(false);
                Cursor.lockState = CursorLockMode.None; 

                instantiatedUI = Instantiate(UiQuestion);
                scriptUI = instantiatedUI.GetComponent<QuestionUI>();
                scriptUI.Statue = gameObject;
                scriptUI.forgive = this;

                scriptPlayer = Player.GetComponent<FirstPersonController>();
                scriptPlayer.enabled = false;

                triggered = false;
                done = true;
                justTriggered = false;
            }

           // Au moment où triggered = true update confirme l'input ici aussi
            /*
            if (Input.GetKeyDown(KeyCode.E) && justTriggered == false) 
            {
                triggered = false;
            }
            */
            
        }
    }
}
