using UnityEngine;
using UnityEngine.SceneManagement;

public class TypeGUI : MonoBehaviour
{
    public int life;
    public static TypeGUI instance;
    public int score; 
    public int highScore;
    public GUISkin skin;
    private bool esc;

    void Start()
    {
        Time.timeScale = 1;
        //life = 10;
        instance = this;
        highScore = PlayerPrefs.GetInt("HiScore");
    }

    void Update()
    {
        esc |= Input.GetKeyDown(KeyCode.Escape);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D");
        if (collision.CompareTag("Word"))
        {
            if (life > 0)
            {
                life -= 1;
                WordSwapner.instance.midBreak = -1;
                Destroy(collision.gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider other)        
    {
        if (other.CompareTag("Word"))
        {   
            if (life > 0)
            {
                life -= 1;
                WordSwapner.instance.midBreak = -1;   
                Destroy(other.gameObject);
            }
        }
    }

    void OnGUI()
    {
        GUI.skin = skin;
        GUI.Label(new Rect(20, 20, 300, 100), "High Score: " + highScore);
        GUI.Label(new Rect(Screen.width - 220, 20, 200, 100), "Score: " + score);
        GUI.Label(new Rect(Screen.width - 220, Screen.height - 120, 200, 100), "Life：" + life);

        if (esc && life != 0)
        {
            Time.timeScale = 0;
            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 50, 200, 100), "Resume"))
            {
                esc = false;
                Time.timeScale = 1;
            }
        }

        if (life == 0)
        {
            esc = true;
            Time.timeScale = 0;

            if (score > highScore)
            {
                PlayerPrefs.SetInt("HiScore", highScore);
                GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 300, 400, 100), "Awesome!");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 50, 400, 100), "Restart"))
            {
                RestartGame();
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 100, 400, 100), "Quit"))
            {
                Application.Quit();
            }
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name);
    }
}
