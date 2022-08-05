using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class DeathHandler : MonoBehaviour
{
    public void QuitGame(){
        Application.Quit();
    }

    public void PlayAgain(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
