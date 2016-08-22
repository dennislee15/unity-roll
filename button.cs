using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour {

    public bool start;
    public bool quit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnMouseUp () {
        if (start)
        {
            SceneManager.LoadScene(1);
        }
        if (quit)
        {
            Application.Quit();
        }
	}
}
