using UnityEngine;
using System.Collections;

public class DeviceController : MonoBehaviour {

	private float condition;

	private bool input0;
	private bool input1;

	private Vector3 pos_mouse;
	private Vector3 pos_current;
	private Vector3 initial_pos;
	// Use this for initialization
	void Start () {
		pos_mouse = Vector3.right;
		condition = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 move_toward1 = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		pos_mouse = move_toward1;

		if ((pos_mouse.x > 6) && (pos_mouse.x < 7)) 
		{
			if((pos_mouse.y > 1) && (pos_mouse.x < 2)) 
			{
				input0 = Input.GetButtonDown("Fire1");
				if(input0)
				{
					Vector3 move_toward = Camera.main.ScreenToWorldPoint (Input.mousePosition);
					pos_mouse = move_toward;
					pos_mouse.z = 0;
					transform.position = pos_mouse;
					initial_pos = pos_mouse;
					condition = 1;
				}
			}
		}

		if(condition == 1) 
		{
			pos_current = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			pos_current.z = 0;
			transform.position = pos_current;
			input1 = Input.GetButtonUp("Fire");
			if(input1)
			{
				transform.position = initial_pos;
				condition = 0;
			}
		}
	}
}
