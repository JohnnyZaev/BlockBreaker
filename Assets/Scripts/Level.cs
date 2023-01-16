using UnityEngine;

public class Level : MonoBehaviour
{
	[SerializeField] private int breakableBlocks; // Delete serialize after done with testing

	public void CountBreakableBlocks()
	{
		breakableBlocks++;
	}
}
