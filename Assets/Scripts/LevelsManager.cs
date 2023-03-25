using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsManager : MonoBehaviour
{
    public int currentLevel = 1;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        //GameObject levelOne = Resources.Load<GameObject>("Prefabs/Level_1");
        //Instantiate(levelOne, new Vector2(-8.484213f, -0.68f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {

            int bricksCount = GameObject.FindGameObjectsWithTag("Brick").Length;
            if (bricksCount == 0)
            {
                currentLevel += 1;
                SceneManager.LoadScene("Winning");
            }
        }
    }
}
