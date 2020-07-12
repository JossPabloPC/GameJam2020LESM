using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public Animator transitionAnim;
    public string sceneName;
    public void PlayGame()
    {
        StartCoroutine(waitDeploy());
    }

    IEnumerator waitDeploy()
    {
        transitionAnim.SetTrigger("start");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }
}
