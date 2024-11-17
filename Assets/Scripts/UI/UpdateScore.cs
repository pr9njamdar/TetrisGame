
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class UpdateScore :MonoBehaviour,IObserver
{
    // Start is called before the first frame update
    int Score=0;
    TextMeshPro ScoreText;
    void Start()
    {
      Grid BlockGrid=GameObject.FindWithTag("Spawner").GetComponent<Grid>();
      BlockGrid.AddObserver(this); 
      ScoreText=FindAnyObjectByType<TextMeshPro>();
    }

    // Update is called once per frame
   
    public  void OnNotify(string Event){
        if(Event=="LineCleared"){
            AddScore();
        }
    }

    void AddScore(){
        Score++;
        ScoreText.text="Score : "+Score;
    }

}
