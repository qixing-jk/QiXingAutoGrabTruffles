using System;
using HarmonyLib;
using StardewModdingAPI;
using StardewValley;

namespace AutoGrabTruffles.Patches;

public class FarmAnimalPatcher
{
	private static IMonitor Monitor;

	private static ModConfig Config;

	private static Pig Pig;

	public FarmAnimalPatcher(IMonitor monitor, ModConfig config, Pig pig)
	{
		Monitor = monitor;
		Config = config;
		Pig = pig;
	}

	public void Apply(Harmony harmony)
	{
		harmony.Patch(AccessTools.Method(typeof(FarmAnimal), "DigUpProduce") ?? throw new InvalidOperationException("Can't find FarmAnimal.findTruffle method."), null, new HarmonyMethod(typeof(FarmAnimalPatcher), "FindTruffle_Postfix"));
	}

	private static void FindTruffle_Postfix(FarmAnimal __instance)
	{
		Pig.Current = null;
		if (Config.EnableAutoGrabTruffles && Pig.IsValid(__instance))
		{
			Pig.Current = __instance;
			Pig.Enqueue(__instance);
		}
	}
}
