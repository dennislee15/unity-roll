using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class score : MonoBehaviour {

    public Text winText;
    public Text winText2;
    public Text mainmenu;
    public playerController player1;
    public player2Controller player2;
    int maxScore = 42;
    int totalScoreTracker = 0;

	// Use this for initialization
	void Start () {
        winText.text = "";
        winText2.text = "";
        mainmenu.text = "";
	}
	
	// Update is called once per frame
	void Update () {
        totalScoreTracker = player1.score1 + player2.score2;
        if (totalScoreTracker == maxScore)
        {
            if (player1.score1 > player2.score2)
            {
                winText.text = "You win!";
                winText2.text = "You lose!";
            }
            else if (player1.score1 < player2.score2)
            {
                winText.text = "You lose!";
                winText2.text = "You win!";
            }
            else
            {
                winText.text = "Tie!";
                winText2.text = "Tie!";
            }
            mainmenu.text = "Return to Menu";
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}
}
