using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowards : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        transform.LookAt(PlayerController.main.transform);
	}
}
