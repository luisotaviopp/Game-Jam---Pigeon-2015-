﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public float lenghtBackground = 41.39f;
	public float nextBackgroundPosition = 93.79f;

	public GameObject[] blocks;

	public float[] Layers;

	public float respawDelay;

	public float forewardRunner = 10.0f;

	public Vector3 minRotation, maxRotation;

	float timeRespaw;

	public float getNextBackgroundPosition()
	{
		nextBackgroundPosition += lenghtBackground;
		return nextBackgroundPosition;
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		timeRespaw += Time.deltaTime; 
		if (respawDelay - timeRespaw < 0) 
		{
			timeRespaw = 0;
			int indicePrefab = Random.Range (0, blocks.Length);
			GameObject instatiate = blocks [indicePrefab];

			float layer = Layers[Random.Range(0,Layers.Length)];

			Vector3 newPosition = new Vector3(Runner.distanceTraveled+forewardRunner,layer, instatiate.transform.position.z);

			Quaternion rotation = new Quaternion(
				Random.Range(minRotation.x, maxRotation.x),
				Random.Range(minRotation.y,maxRotation.y),
			    Random.Range(minRotation.z,maxRotation.z),0f);

			GameObject.Instantiate (instatiate,newPosition,rotation);
		}
	}
}
