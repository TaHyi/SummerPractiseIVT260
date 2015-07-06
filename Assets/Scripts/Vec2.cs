using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour 
{
	public Object prefap_pikachu;
	int ROW, COL;
	public int[][] MAP;
	public bool[][] SHIT;
	public Vec2[][] SHIT_ROOT_POS;
	public Vec2 POS1;
	public Vec2 POS2;
	public Vector3[][] POS;
	public static int MIN_X;
	public static int MIN_Y;
	public static int CELL_WIDH = 28;
	public static int CELL_HEIGHT = 32;
	void Start () 
	{
		prefap_pikachu = Resources.Load("item");
		if (prefap_pikachu == null) Debug.Log("123");
		LMap(10, 15);
		RandomMap();
	}
	void Update () 
	{
		
	}
	void AddPikachu(int type,Vector3 pos,int width,int height)
	{
		GameObject g = Instantiate(prefap_pikachu) as GameObject;
		g.transform.parent = this.transform;
		g.transform.position = pos;
		Sprite sprite = Resources.Load("Images/item/item"+type, typeof(Sprite)) as Sprite;
		g.GetComponent<SpriteRenderer>().sprite = sprite;
		g.transform.localScale = new Vector3(Mathf.Abs(width * 1.0f / sprite.bounds.size.x), Mathf.Abs (- height * 1.0f / sprite.bounds.size.y), 1);
	}
	public void LMap(int row, int col)
	{
		
		CELL_HEIGHT = (int)(80f / (ROW - 2));
		CELL_WIDH = (int)(CELL_HEIGHT * 0.9f);
		
		ROW = row;
		COL = col;
		MAP = new int[ROW][];
		SHIT = new bool[ROW][];
		SHIT_ROOT_POS = new Vec2[ROW][];
		POS = new Vector3[ROW][];
		
		MIN_X = -COL * CELL_WIDH / 2;
		MIN_Y = -(ROW  ) * CELL_HEIGHT / 2;
		
		for (int i = 0; i < ROW; i++)
		{
			MAP[i] = new int[COL];
			SHIT[i] = new bool[COL];
			SHIT_ROOT_POS[i] = new Vec2[COL];
			POS[i] = new Vector3[COL];
			for (int j = 0; j < COL; j++)
			{
				SHIT[i][j] = false;
				MAP[i][j] = -1;
				SHIT_ROOT_POS[i][j] = new Vec2();
				
				
				POS[i][j] = new Vector3(0, 0, 0);
				POS[i][j].x = MIN_X + j * CELL_WIDH + CELL_WIDH / 2;
				POS[i][j].y = MIN_Y + i * CELL_HEIGHT + CELL_HEIGHT / 2;
				POS[i][j].z = i / 10.0f;
			}
			
			
			
		}
		//PrintMap();
		//RandomMap();
		//CheckAndSwapThings();
	}
	
	void RandomMap()
	{
		for(int i=1;i< ROW-1;i++)
		{
			for(int j=1;j< COL-1;j++)
			{
				AddPikachu(Random.Range(0, 36), POS[i][j],CELL_WIDH,CELL_HEIGHT);
			}
		}
	}
	
	
}
