using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

	public enum RotationAxes {
		MouseXandY=0,
		MouseX = 1,
		MouseY = 2
	
	}
	public RotationAxes axes = RotationAxes.MouseXandY;
	public float sensitivityHorz = 8.0f;
	public float sensitivityVert = 8.0f;
	public float minimumView = -45.0f;
	public float maximumView = 45.0f;

	private float _rotation = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (axes == RotationAxes.MouseX) {
			transform.Rotate (0, Input.GetAxis ("Mouse X") * sensitivityHorz, 0);
		} else if (axes == RotationAxes.MouseY) {
			_rotation -= Input.GetAxis ("Mouse Y") * sensitivityVert;
			_rotation = Mathf.Clamp (_rotation, minimumView, maximumView);

			float rotationY = transform.localEulerAngles.y;

			transform.localEulerAngles = new Vector3 (_rotation, rotationY, 0);
		} else {
			_rotation -= Input.GetAxis ("Mouse Y") * sensitivityVert;
			_rotation = Mathf.Clamp (_rotation, minimumView, maximumView);

			float delta = Input.GetAxis ("Mouse X") * sensitivityHorz;
			float rotationYDelta = transform.localEulerAngles.y + delta;

			transform.localEulerAngles = new Vector3 (_rotation, rotationYDelta, 0);


		
		
		}
	}
}
