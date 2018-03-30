using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour {
	
	public static float Speed = 0;
	public static int TimeSpan = 60;
	public static float step = 0;

	static float StepLen;
	float Buffer;
	
	public RectTransform Bar;
	public Text Out;

	void Awake()
	{
		Buffer = Bar.anchoredPosition.x;
		StepLen = (transform.GetComponent<RectTransform>().rect.width-(Buffer*2)) / TimeSpan;
    }
	
	void Update ()
	{
		Bar.anchoredPosition = new Vector2(Buffer + (step * StepLen),0);
		step += (Speed * Time.deltaTime);
		if (step > TimeSpan)
		{
			step = TimeSpan;
			Pause();
		}
		else if (step < 0)
		{
			step = 0;
			Pause();
		}

		string minutes = Mathf.Floor(step / 60).ToString("00");
		string seconds = (step % 60).ToString("00");
		string milliseconds = Mathf.Floor((step - Mathf.Floor(step)) * 100).ToString("00");

		Out.text = "COUNT  " + minutes + ":" + seconds + ":" + milliseconds;

	}

	public static void Rewind() { Speed = -1; }
	public static void RewindFF() { Speed = -5; }
	public static void Play() { Speed = 1; }
	public static void PlayFF() { Speed = 5; }
	public static void Pause() { Speed = 0; }
}
