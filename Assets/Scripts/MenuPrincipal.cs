using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour{

    public string startLevel;
    public string optionLevel;
    
    public void NewGame()
    {
        SceneManager.LoadScene(startLevel);
    }

    public void Options()
    {
        SceneManager.LoadScene(optionLevel);
    }
}
