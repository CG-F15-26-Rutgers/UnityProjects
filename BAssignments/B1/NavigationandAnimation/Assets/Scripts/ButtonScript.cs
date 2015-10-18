using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonScript : MonoBehaviour {

    public Button agents;
    public Button animation;
    public Button together;
    public Button quit;

	// Use this for initialization
	void Start () {
        agents = agents.GetComponent<Button>();
        animation = animation.GetComponent<Button>();
        together = together.GetComponent<Button>();
	}
	
    public void startOne()
    {
        Application.LoadLevel(1);
    }

    public void startAnim()
    {
        Application.LoadLevel(2);
    }

    public void startTogether()
    {
        Application.LoadLevel(3);
    }

    public void quitGame()
    {
        Application.Quit();
    }

}
