using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PostEffectScript : MonoBehaviour {

	public Material mat;

	void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		if (Scroller.Speed < 0 || Scroller.Speed > 1)
		{
			mat.SetFloat("_Dir", (Mathf.Abs(Scroller.Speed)==1)?Scroller.Speed:Scroller.Speed/2);
			Graphics.Blit(src, dest, mat);
		}
		else
		{
			Graphics.Blit(src, dest);
		}
	}
}
