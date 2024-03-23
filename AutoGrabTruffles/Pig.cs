using System.Collections.Generic;
using StardewValley;

namespace AutoGrabTruffles;

public class Pig
{
	public FarmAnimal Current;

	public Queue<FarmAnimal> Queue = new Queue<FarmAnimal>();

	public static bool IsValid(FarmAnimal pig)
	{
		return pig.ownerID.Value == Game1.player.UniqueMultiplayerID;
	}

	public void Enqueue(FarmAnimal pig)
	{
		Queue.Enqueue(pig);
	}

	public bool TryDequeue(out FarmAnimal pig)
	{
		return Queue.TryDequeue(out pig);
	}
}
