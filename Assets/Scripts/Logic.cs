using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Logic : MonoBehaviour
{
    public GameObject gameOverScene;
    public void restartGame()
    {

        SceneManager.LoadScene("TutorialLevel"); //SceneManager.GetActiveScene().name
    }

    public void gameOverUI()
    {
        gameOverScene.SetActive(true);
    }
}
