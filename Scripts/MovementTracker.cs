using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTracker : MonoBehaviour {

	List<Move> Movements = new List<Move>();
	int index = 0;

	void Update ()
	{
		try
		{
			if (Movements[index].Begining > Scroller.step && index > 0)
			{
				index--;
			}
			else if (Movements[index].Ending < Scroller.step && index < Movements.Count - 1)
			{
				index++;
			}
			print("Moving to " + Movements[index].GetAtTick(Scroller.step));
			transform.position = Movements[index].GetAtTick(Scroller.step);
		}
		catch { }
	}
}

public abstract class Move
{
	public float Begining;
	public float Ending;

	protected float Xstart;
	protected float Xend;

	public Move(float Begin, float End, Vector2 Start, Vector2 EndAt)
	{
		Begining = Begin;
		Ending = End;
		Xstart = Start.x;
		Xend = EndAt.x;
	}

	public abstract Vector2 GetAtTick(float tick);
}

public class Dash : Move
{
	float xXmod;
	float xYmod;
	float yXmod;
	float yYmod;

	public Dash(float b, float e, Vector2 Start, Vector2 End) : base(b,e,Start,End)
	{
		Vector2 xp1 = new Vector2(b, Start.x);
		Vector2 xp2 = new Vector2(e, End.x);
		Vector2 yp1 = new Vector2(b, Start.y);
		Vector2 yp2 = new Vector2(e, End.y);

		xXmod = (xp2.y - xp1.y) / (xp2.x - xp1.x);
		xYmod = -((xXmod * xp1.x) - xp1.y);

		yXmod = (yp2.y - yp1.y) / (yp2.x - yp1.x);
		yYmod = -((yXmod * yp1.x) - yp1.y);

		MonoBehaviour.print("Calculated to start at " + GetAtTick(b) + " from " + Start);
		MonoBehaviour.print("Calculated to end at " + GetAtTick(e) + " from " + End);
	}

	public override Vector2 GetAtTick(float tick)
	{
		return new Vector2((xXmod * tick) + xYmod, (yXmod * tick) + yYmod);
	}
}
