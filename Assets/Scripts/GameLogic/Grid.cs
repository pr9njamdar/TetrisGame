
using System.Collections.Generic;
using UnityEngine;


public class Grid : Subject
{
    public GameObject[] Blocks;
    public Transform[,] grid=new Transform[11,21];
    int LengthOfBlocks=0;

    
    // Start is called before the first frame update
    void Start()
    {
     Blocks=Resources.LoadAll<GameObject>("Blocks"); 
     LengthOfBlocks=Blocks.Length;  
     SpawnBlock();    
    }

    // Update is called once per frame
    void Update()
    {
     for(int i=1;i<grid.GetLength(1);i++)
     {
        CheckAndClear(i);
     }   
    }
    
    void CheckAndClear(int l){
        for(int i=1;i<grid.GetLength(0)-1;i++){
            if(grid[i,l]==null)return;
        }
        
        for(int i=1;i<grid.GetLength(0)-1;i++){
            Destroy(grid[i,l].gameObject);
            grid[i,l]=null;           
        }
        NotifyAll("LineCleared");
        for(int i=l+1;i<grid.GetLength(1);i++){
            for(int j=1;j<grid.GetLength(0);j++){
                if(grid[j,i]!=null && grid[j,i-1]==null){
                    Debug.Log(i+" "+j);
                    Transform SubBlock=grid[j,i];
                    grid[j,i]=null;
                    SubBlock.transform.position+=Vector3.back;
                    grid[j,i-1]=SubBlock;                
                }
            }

        }
            
    }

    public void SpawnBlock(){  
        // last row available to fill 19 if any block sets at 20th row game gets over
        for(int i=0;i<grid.GetLength(0);i++){
            if(grid[i,20]!=null){
                Time.timeScale=0f;
                Notify("GameOver");
            }
        }      
        int BlockIndex=Random.Range(0,LengthOfBlocks);
        Instantiate(Blocks[BlockIndex]);        
    }
    public void Notify(string Event){
        NotifyAll(Event);
    }
    public void PrintGrid(){
        for(int i=grid.GetLength(1)-1;i>=0;i--){
            string row="";
           for(int j=grid.GetLength(0)-1;j>=0;j--){
            if(grid[j,i]!=null)row+="1 ";
            else row+="0 ";
        } 
        row+="\n";
        Debug.Log(row);
        }
    }
}
