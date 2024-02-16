using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{
    public TextMeshProUGUI finalPointsText;
    public TextMeshProUGUI finalTimeText;
    public GameObject restartButton;
    public GameObject quitButton;

    private PlayerMovement player;
    private TimerScript timer;
    private PlayerCamera playerCam;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        timer = FindObjectOfType<TimerScript>();
        playerCam = FindObjectOfType<PlayerCamera>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            timer.stopped = true;

            finalPointsText.text = ("You got " + player.points.ToString() + " points.");
            finalTimeText.text = ("You took " + timer.time.ToString("F0") + " seconds.");

            Destroy(player.airDashText);
            Destroy(player.pointsText);
            Destroy(timer.timerText);

            finalPointsText.gameObject.SetActive(true);
            finalTimeText.gameObject.SetActive(true);
            restartButton.SetActive(true);
            quitButton.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            playerCam.canLook = false;

            Time.timeScale = 0;
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
