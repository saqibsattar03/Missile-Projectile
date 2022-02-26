using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    int score;
    public GameObject panel;
    public Transform player;
    public static GameManager instance;

	private void Awake()
	{
        if (instance != null) 
        {
            Destroy(gameObject);
        }
		else
		{
            instance = this;
		}
	}
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score:" + score;
    }

    public void addScore() 
    {
        score += 25;
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
