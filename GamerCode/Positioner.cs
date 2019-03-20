using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Positioner : MonoBehaviour{

	public Vector3Int origin_pos = new Vector3Int(0,0,0);
	public Vector3Int offset_pos = new Vector3Int(1,0,0);
	//public int numberOfPosition = 0;

	public Vector3Int[] GetPositionFromPixelColor(Texture2D texture, Color color)
	{
		List<Vector3Int> vec = new List<Vector3Int>();
		for (int i = 0; i < texture.width; i++)
		{
			for (int j = 0; j < texture.height; j++)
			{
				if(texture.GetPixel(i,j) == color){
					vec.Add(new Vector3Int(i,0,j) * offset_pos + origin_pos);
				}
			}
		}
		return vec.ToArray();
	}

	public void SetOrigin(Vector3Int vec)
	{
		origin_pos = vec;
	}

	public void SetOffset(Vector3Int vec)
	{
		offset_pos = vec;
	}

	public Vector3Int[] BuildLinePosition(int length)
	{
		Vector3Int[] vec = new Vector3Int[length];
		for (int i = 0; i < length; i++)
		{
			vec[i] = new Vector3Int(i,i,i) * offset_pos + origin_pos;
		}

		return vec;
	}

	public Vector3Int[] BuildAreaPosition(int width, int height)
	{
		List<Vector3Int> vecmaster = new List<Vector3Int>();
		Vector3Int[] vecline = BuildLinePosition(width);
		for (int i = 0; i < height; i++)
		{
			origin_pos = new Vector3Int(0,i,0);
			vecmaster.AddRange(BuildLinePosition(width));
		}
		return vecmaster.ToArray();
	}

	public Vector3Int[] BuildOutlineAreaPosition(int width, int height)
	{
		List<Vector3Int> vecmaster = new List<Vector3Int>();
		Vector3Int[] veclineTop = BuildLinePosition(width);
		origin_pos = new Vector3Int(width,0,0);
		offset_pos = new Vector3Int(0,-1,0);
		Vector3Int[] veclineRight = BuildLinePosition(height);
		origin_pos = new Vector3Int(width,-height,0);
		offset_pos = new Vector3Int(-1,0,0);
		Vector3Int[] veclineBottom = BuildLinePosition(width);
		origin_pos = new Vector3Int(0,-height,0);
		offset_pos = new Vector3Int(0,1,0);
		Vector3Int[] veclineLeft = BuildLinePosition(height);

		vecmaster.AddRange(veclineTop);
		vecmaster.AddRange(veclineRight);
		vecmaster.AddRange(veclineBottom);
		vecmaster.AddRange(veclineLeft);
		return vecmaster.ToArray();
	}

	public Vector3Int[] ChessEffect(Vector3Int[] vec)
	{
		List<Vector3Int> vecmaster = new List<Vector3Int>();
		for (int i = 0; i < vec.Length; i++)
		{
			if(i%2==0){
				vecmaster.Add(vec[i]);
			}
		}
		return vecmaster.ToArray();
	}

	Vector3Int[] BuildCirclePosition(){
		//not implemented
		return null;
	}
}
