using System;
using UnityEngine;
public class FallingState : BlockBaseState
{

    float minX = 0.1f,minZ = 0.5f,maxX = 9.5f,maxZ = 19.5f;// Adding extents to avoid overshooting
    float moveStep = 1f; // Adjust this if necessary to control the step size
    float fallSpeed = 2f; // Normal fall speed
    float timer = 0;
    float FastTimer = 0;

    BlockStateManager Block;
    public override void UpdateState(BlockStateManager Block)
    {
        timer += Time.deltaTime;

        // Normal falling with regular speed
        if (timer > (1 / fallSpeed) && !Input.GetKey(KeyCode.DownArrow))
        {
            MoveDown();
            timer = 0;
        }

        // If down arrow is pressed, move down faster
        if (Input.GetKey(KeyCode.DownArrow))
           MoveDownFast();

        // Horizontal movement
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            MoveLeft();
       
        if (Input.GetKeyDown(KeyCode.RightArrow))       
            MoveRight();

        if(Input.GetKeyDown(KeyCode.Space)){
            Block.transform.eulerAngles-=new Vector3(0,90,0);
            if(!IsValidMove())
            Block.transform.eulerAngles-=new Vector3(0,90,0);
        }
       
    }
    public override void EnterState(BlockStateManager BlockManager)
    {
        Block = BlockManager;
    
    }


    bool IsValidMove()
    {
        foreach (Transform subblock in Block.transform)
        {
            int x=Mathf.FloorToInt((float)Math.Round(subblock.transform.position.x)),
            z=Mathf.FloorToInt((float)Math.Round(subblock.transform.position.z));
            
            if (subblock.transform.position.x > maxX || subblock.transform.position.x < minX ||
             Block.Spawner.grid[x,z]!=null)
            return false;            
        }
        return true;
    }

    void MoveLeft()
    {
        Block.transform.position += Vector3.left * moveStep;
        if (!IsValidMove())
            Block.transform.position -= Vector3.left * moveStep;
    }

    void MoveDown()
    {
        Block.transform.position += Vector3.back * moveStep;
        foreach (Transform subblock in Block.transform)
        {
            if (subblock.transform.position.z < minZ ||
            Block.Spawner.grid[Mathf.FloorToInt((float)Math.Round(subblock.transform.position.x)),
            Mathf.FloorToInt((float)Math.Round(subblock.transform.position.z))]!=null)
            {
                Block.transform.position -= Vector3.back * moveStep; 
                Block.Spawner.Notify("Dropped");
               // if(!Block.Audio.isPlaying)
                //Block.Audio.Play();               
                Block.SwitchState(Block.Settle);
                return;
            }
        }
    }

    // Function for faster falling when down arrow is pressed
    void MoveDownFast()
    {
        FastTimer += Time.deltaTime;
        if (FastTimer > 0.25)
        {
            MoveDown();
            FastTimer = 0;
        }

    }
     
    void MoveRight()
    {
        Block.transform.position += Vector3.right * moveStep;
        if (!IsValidMove())
            Block.transform.position -= Vector3.right * moveStep;
    }
}