using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PageState : MonoBehaviour {

	public static PageState instance = null;
	
	public int currentPage = 1;
	
	void Awake()
	{
		
		if (instance == null)
		{
			instance = this;
		
			currentPage = 1;
		}
		else
			Destroy(gameObject);
		
		DontDestroyOnLoad(gameObject);
	}
}
