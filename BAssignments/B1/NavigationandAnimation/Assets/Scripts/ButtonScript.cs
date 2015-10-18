using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonScript : MonoBehaviour {

    public Button agents;
    public Button animation;
    public Button together;
    public Button menu;
    public Button quit;

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

    public void toMenu()
    {
        Application.LoadLevel(0);
    }

}
