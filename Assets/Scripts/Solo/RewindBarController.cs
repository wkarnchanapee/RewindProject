using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RewindBarController : MonoBehaviour
{
    [SerializeField] Image rewindFill;
    float maxFillAmnt = 0.5f;
    PlayerController playCtrl;
    [SerializeField] float fillPerc = 0.5f;
    
    // Use this for initialization

    void Start()
    {
        playCtrl = PlayerController.main;
    }

    // Update is called once per frame
    void Update()
    {
        fillPerc = ((playCtrl.rewindLimit - playCtrl.rewindCounter) / (float)playCtrl.rewindLimit) * 100f;
        
        fillPerc = (fillPerc / 100f) / 2f;
        
        rewindFill.fillAmount = fillPerc;
    }
}
