using System;
using UnityEngine;
public class SettleState : BlockBaseState{
  public override void UpdateState(BlockStateManager Block){}
  public override void EnterState(BlockStateManager Block){

    // register the block in the grid
    foreach (Transform subBlock in Block.transform)
    {
      
    // Floor the local position to get the grid coordinates
    //Debug.Log("X:"+subBlock.position.x+" Z:"+subBlock.position.z);
    int x = Mathf.FloorToInt((float)Math.Round(subBlock.position.x));
    int z = Mathf.FloorToInt((float)Math.Round(subBlock.position.z));

   // Debug.Log("X:"+x+" Z:"+z);    
    Block.Spawner.grid[x, z] = subBlock;  
    
   }
   Block.Spawner.SpawnBlock();
  }
 
}