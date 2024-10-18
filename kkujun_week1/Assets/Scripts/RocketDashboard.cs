using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketDashboard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentScoreTxt;
    [SerializeField] private TextMeshProUGUI highScoreTxt;

    public GameObject rocket;
    int score;

    private string KeyName = "HighScore";
    private int highScore = 0;

    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
        highScore = PlayerPrefs.GetInt(KeyName, 0);
    }

    private void Update()
    {
        if (score <= rocket.transform.position.y)
        {
            score = (int)rocket.transform.position.y;
        }

        if (score >= highScore)
        {
            PlayerPrefs.SetInt(KeyName, score);
        }

        //텍스트를 변경하기 위해서는 아래와 같이 합니다.
        currentScoreTxt.text = $"{score} M";
        highScoreTxt.text = $"HIGH : {highScore} M";
    }

    public void Retry()
    {
        //씬 불러오기
        SceneManager.LoadScene("RocketLauncher");
    }
}
