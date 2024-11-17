using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour,IObserver
{
    public Animator CamAnim;
    AudioSource Clip;
    Grid  BlockGrid;

    void Start(){
        CamAnim=FindAnyObjectByType<Camera>().GetComponent<Animator>();
        BlockGrid=GameObject.FindWithTag("Spawner").GetComponent<Grid>();
        BlockGrid.AddObserver(this);
        Clip=GetComponent<AudioSource>();
    }
    public void  OnNotify(string Event){
        if(Event=="LineCleared")
        ShakeCamera();
    }

    public void ShakeCamera(){
        Debug.Log("Vibrate...");
        CamAnim.SetTrigger("Shake");
        if(!Clip.isPlaying)
        Clip.Play();
    }
}
