using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle: MonoBehaviour {
	public int ID; // номер должен соответствовать данной "костяшке"

	public void Awake(){
		GetComponent<BoxCollider2D> ().enabled = true;
	}

	// текущая и пустая клетка, меняются местами
	void ReplaceBlocks(int x, int y, int XX, int YY)
	{
		GameController.grid[x,y].transform.position = GameController.position[XX,YY];
		GameController.grid[XX,YY] = GameController.grid[x,y];
		GameController.grid[x,y] = null;
		GameController.GameFinish();
	}

	void OnMouseDown()
	{
		for(int y = 0; y < 4; y++)
		{
			for(int x = 0; x < 4; x++)
			{
				if(GameController.grid[x,y])
				{
					if(GameController.grid[x,y].GetComponent<Puzzle>().ID == ID)
					{
						if(x > 0 && GameController.grid[x-1,y] == null)
						{
							ReplaceBlocks(x,y,x-1,y);
							return;
						}
						else if(x < 3 && GameController.grid[x+1,y] == null)
						{
							ReplaceBlocks(x,y,x+1,y);
							return;
						}
					}
				}
				if(GameController.grid[x,y])
				{
					if(GameController.grid[x,y].GetComponent<Puzzle>().ID == ID)
					{
						if(y > 0 && GameController.grid[x,y-1] == null)
						{
							ReplaceBlocks(x,y,x,y-1);
							return;
						}
						else if(y < 3 && GameController.grid[x,y+1] == null)
						{
							ReplaceBlocks(x,y,x,y+1);
							return;
						}
					}
				}
			}
		}
	}
}
