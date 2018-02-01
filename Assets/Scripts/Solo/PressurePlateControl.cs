using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressurePlateControl : ActivatableObject
{
    
    Vector3 startPos;
    [SerializeField] int openAtKeyStage = 0;
    float counter;
    float resetTime = 0.2f;

    // Use this for initialization
    void Start() {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update() {

        if (counter > 0) counter -= Time.deltaTime;

        if (SceneManager.GetActiveScene().name != "Hub")
        {
            if (on)
            {
                transform.position = startPos - new Vector3(0, +0.2f, 0);
            }
            else
            {
                transform.position = startPos;
            }
        } else
        {
            if (GameController.main.keys == openAtKeyStage)
            {
                if (on)
                {
                    transform.position = startPos - new Vector3(0, +0.2f, 0);
                }
                else
                {
                    transform.position = startPos;
                }
            }
            
        }
        

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" || other.tag == "echo")
        {
            if (SceneManager.GetActiveScene().name == "Hub")
            {   if (GameController.main.keys == openAtKeyStage || openAtKeyStage == -1)
                {
                    on = true;
                    counter = resetTime;
                }
                
            } else
            {
                on = true;
                counter = resetTime;
            }
                
        }
            
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Echo")
        {
            //FMODUnity.RuntimeManager.PlayOneShot(sfx);
        }
    }

    private void LateUpdate()
    {
        if (counter < 0) on = false;
    }


}
