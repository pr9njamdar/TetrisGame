
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour,IObserver
{
    // Start is called before the first frame update
    Grid BlockGrid;
    GameObject GameOverScreen;
    void Start()
    {
     BlockGrid=GameObject.FindWithTag("Spawner").GetComponent<Grid>();
     BlockGrid.AddObserver(this);
     GameOverScreen=GameObject.FindWithTag("GameOverScreen");
     GameOverScreen.SetActive(false);     
    }

    public void RestartGame(){
        GameOverScreen.SetActive(false);
        Time.timeScale=1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   
    public void OnNotify(string Event){
        if(Event=="GameOver"){
            GameOverScreen.SetActive(true);
        }
    }
}
