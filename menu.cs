using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {

    void Start() { }

    public void onClickCustom(int index){
        Debug.Log("AHAHAHAH");
        SceneManager.LoadScene(index);

        //Application.Quit ();
    }
}
