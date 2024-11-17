using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockStateManager : MonoBehaviour
{
    BlockBaseState CurrentState;
    public Grid Spawner;
    public FallingState Falling=new FallingState();
    public SettleState Settle = new SettleState();

    public AudioSource Audio;
    
    
    
    void Start()
    {
       Spawner=GameObject.FindWithTag("Spawner").GetComponent<Grid>();
       transform.position=new Vector3(5,0,18);
       CurrentState=Falling;
       CurrentState.EnterState(this); 
       Audio=GetComponent<AudioSource>();
    }

    void Update()
    {
      CurrentState.UpdateState(this);
    }

   

    public void SwitchState(BlockBaseState Block){
        CurrentState=Block;
        Block.EnterState(this);
    }

}