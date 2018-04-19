using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWin : MonoBehaviour {
	
	private int sum = 0;
	private int zero = 0;
	int [] row_board=new int[16]{1,2,3,4,5,6,7,8,9,10,11,12,13,15,14,0};

	public void Start(){
	//	Possibility (row_board);
	}

	//If there is no solution in game, shuffle counts
	public int[] Shuffle(bool check){
		int tmp;
		if (check == true) {
			print ("POSSIBILITY=TRUE");
			return row_board;
		} else {
			print ("POSSIBILITY=FALSE");
			for (int i = 15; i > 0; i--) {
				int j = Random.Range (0, 16);
				tmp = row_board [i];
				row_board [i] = row_board[j];
				row_board [j] = tmp;
			}
		//	Possibility (row_board);
			return row_board; 
		}
	}

	//Check if player can win the game
	public void Possibility(int[] mas){
		//int z = 0;
//		for (int y = 0; y < 4; y++)
//			for (int x = 0; x < 4; x++) {
//				
//			}

//
//		for (int i = 0; i < 10; i++)
//			for (int j = 0; j < 10; j++)
//			{
//				m1[z] = m2[i, j];
//				z++;
//			}


		//Четное - есть решение, нечетное - нету
		for (int i = 0; i < 16; i++) {
			if (mas [i] == 0) {
				zero = i/4+1;
					}
			else 
				for (int k = i; k < 16; k++)
				{
					if (mas [i] > mas[k]&& mas[k]!=0) 
					{
						sum++;
					}
				}
			}

		for (int i = 0; i < 16; i++) {
			print ("mas   "+mas[i]);
		}

		print ("sum - " + sum + " zero - " + zero);
		if ((zero + sum) % 2 == 0) {
			Debug.Log ("There is a solution");
			Shuffle(true);
		} else {			
			Debug.Log ("There is NO solution... Reshuffling... ");
			Shuffle (false);
		}
	}
}
