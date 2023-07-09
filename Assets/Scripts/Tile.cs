using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{ 
	public Vector3 CenterLocation()
    {
		return this.gameObject.transform.position; 
	}

}
