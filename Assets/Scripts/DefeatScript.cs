using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class DefeatScript : MonoBehaviour
{
    public void GameOver(GameObject bird)
    {
        StartCoroutine(GameObject.FindGameObjectWithTag("Respawn").GetComponent<ScreenFade>().FadeScreen(+1));
        bird.GetComponent<Player_FSM>().BirdFuckingDies();
        StartCoroutine(RestartGame());
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
