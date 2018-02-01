using UnityEngine;
using System.Collections;

public class DoorControl : ActivatableObject
{
    
    [SerializeField] float openAmount = 3f;
    Vector3 startPos;
    public GameObject[] trigger = new GameObject[1];
    public ActivatableObject[] triggerCtrl = new ActivatableObject[1];
    Vector3 openPos;
    [SerializeField] float openSpd = 0.5f;
    public GameObject doorSfx;

    //used for counting triggers
    [SerializeField] int ii = 0;
    
    // Use this for initialization
    void Start()
    {
        doorSfx = transform.GetChild(0).gameObject;
        startPos = transform.position;
        openPos = startPos - (-transform.up * openAmount);
        for (int i = 0; i < trigger.Length; i++)
        {
            triggerCtrl[i] = trigger[i].GetComponent<ActivatableObject>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        ii = 0;
        for (int i = 0; i < triggerCtrl.Length; i++)
        {
            if (triggerCtrl[i].on == true)
            {
                ii++;
            }
        }

        if (ii >= triggerCtrl.Length)
        {
            on = !startCondition;
            doorSfx.SetActive(true);
            
        } else
        {
            on = startCondition;
            doorSfx.SetActive(false);
        }

        if (on)
        {
            transform.position = Vector3.Slerp(transform.position, openPos, openSpd);
            
            
        } else
        {
            
            transform.position = Vector3.Slerp(transform.position, startPos, openSpd);
        }
        
    }

    
}
