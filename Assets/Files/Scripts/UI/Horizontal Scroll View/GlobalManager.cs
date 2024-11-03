using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalManager : MonoBehaviour
{
	public static GlobalManager instance;
	public int PageCount;

	void Awake()
	{
		instance = this;
	}
}