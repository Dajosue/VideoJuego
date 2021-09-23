using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
	//Public Variables
	[Header("Call 'Shake()' to shake")]
	[Range(0, 2)]
	public float intensity = 0.2f;
	[Range(0, 200)]
	public float speed = 50;
	[Range(0.001f, 3)]
	public float length = 0.5f;

	//Private Varibles
	private Vector3 startPos;
	private bool isShook;
	private Vector3 randPos;
	private Vector3 randPosRev;
	private float vel;
	private float startTime;

	public Transform player;

	void Update()
	{

		startPos = player.transform.position;

		if (isShook)
		{
			//Find drop
			///1 + ((StartTime - Current) / Length)
			float drop = 1 + ((startTime - Time.time) / length);

			//Finish if done
			if (drop <= 0)
			{
				isShook = false;
				transform.position = startPos;
				return;
			}

			//Find velocity as sin
			vel = Mathf.Sin((Time.time - startTime) * speed) * drop;

			if (vel > 0)
			{
				//Use randpos
				transform.position = Vector3.Lerp(startPos, randPos, vel);
			}
			else
			{
				//Reverse vel
				vel *= -1;

				//Use randposrev
				transform.position = Vector3.Lerp(startPos, randPosRev, vel);
			}
		}
	}

	public void Shake()
	{
		//Get random position and other sided pos
		randPos = Random.insideUnitSphere * intensity;
		randPosRev = -randPos;

		//Make pos relative to me
		randPos += transform.position;
		randPosRev += transform.position;

		//Get start time
		startTime = Time.time;

		//Start the shakin
		isShook = true;
	}
}