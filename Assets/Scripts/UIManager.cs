using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    Text scoreText;

    [SerializeField]
    Text livesText;

    [SerializeField]
    GameObject GameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + LevelController.shared.score.ToString().PadLeft(3, '0');
        livesText.text = "Lives x" + LevelController.shared.lives.ToString().PadLeft(2, '0');
    }

    public void EndLevel()
    {
        Time.timeScale = 0;
        GameOverPanel.SetActive(true);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);        
    }
}
