using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	void Update () {
		if (Input.GetButton("ShiftBack") && !Input.GetButton("ShiftForward"))
		{
			if (Input.GetButton("FastForward"))
			{
				Scroller.RewindFF();
			}
			else
			{
				Scroller.Rewind();
			}
		}
		else if (Input.GetButton("ShiftForward") && !Input.GetButton("ShiftBack"))
		{
			if (Input.GetButton("FastForward"))
			{
				Scroller.PlayFF();
			}
			else
			{
				Scroller.Play();
			}
		}
		else if (Input.GetButton("ShiftForward") && Input.GetButton("ShiftBack"))
		{
			Scroller.Pause();
		}
		else if (Input.GetButtonUp("ShiftBack"))
		{
			Scroller.Pause();
		}
		else if (Input.GetButtonUp("ShiftForward"))
		{
			Scroller.Pause();
		}
	}
}
