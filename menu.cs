using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {

    void Start() { }

    public void onClickCustom(int index){
        SceneManager.LoadScene(index);

    }
}
