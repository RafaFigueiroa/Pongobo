using UnityEngine;
using UnityEngine.UI;
using LootLocker.Requests;
using UnityEngine.SceneManagement;

public class EndGameController : MonoBehaviour
{
    public Canvas endCanvas;
    public Canvas gameCanvas;
    public Text scoreText;
    public Text finalScoreText;
    public int finalScore;
    public string ID = "20904";
    public InputField PlayersName;

    // Start is called before the first frame update
    void Start()
    {
        //confirma que o canvas está invisivel
        if(endCanvas != null)
        {
            endCanvas.enabled = false;
        }

        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if(!response.success)
            {
                Debug.Log("error starting lootlocker session");
                return;
            }

            Debug.Log("token" + response.session_token);
        });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            //pausa
            Time.timeScale = 0f;

            //desativa o canvas do placar
            if(gameCanvas != null)
            {
                finalScore = int.Parse(scoreText.text);
                gameCanvas.enabled = false;
            }

            //ativa o canvas de fim de jogo
            if (endCanvas != null)
            {
                finalScoreText.text = finalScore.ToString();
                endCanvas.enabled = true;
                Debug.Log("Final Score: " + finalScore);
            }
        }
    }

    public void SubmitScore()
    {
        LootLockerSDKManager.SubmitScore(PlayersName.text, int.Parse(finalScoreText.text), ID, (response) =>
        {
            if (response.statusCode == 200)
            {
                Debug.Log("sucessful");
                BackToHome("MenuScene");
            }
            else
            {
                Debug.Log("failed" + response.errorData);
            } 
        });

    }

    public void BackToHome(string MenuScene)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(MenuScene);
    }

    public void ReloadScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneIndex);
    }
}
