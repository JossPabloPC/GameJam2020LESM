using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameControl : MonoBehaviour
{
    private bool hasPlayed;
    public GameObject WonCanvas;
    public TextMeshProUGUI WonText;
    // Start is called before the first frame update
    void Start()
    {
        WonCanvas.SetActive(false);
        hasPlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer.Instance.timeIsUp == true && hasPlayed == false)
        {
            Debug.LogWarning("Gana bloqueador");
            SoundController.instance.music_bit.clip = SoundController.instance.blockerWin;
            SoundController.instance.music_bit.Play();
            //StartCoroutine(PlayGanaEscapista());
            hasPlayed = true;
            WonCanvas.SetActive(true);
            WonText.text = "Blocker Won";
            Time.timeScale = 0.5f;

        }
        if (PlayerCollision.instance.power == -1 && hasPlayed == false)
        {
            Debug.LogWarning("Gana EScapista");
            SoundController.instance.music_bit.clip = SoundController.instance.escapistWin;
            SoundController.instance.music_bit.Play();
            hasPlayed = true;
            WonCanvas.SetActive(true);
            WonText.text = "Escapist Won";
            Time.timeScale = 0.5f;


        }
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
