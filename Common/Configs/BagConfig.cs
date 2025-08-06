using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using Terraria;
using Terraria.ModLoader.Config;

namespace MSStarterBag.Common.Configs
{
	public class BagConfig : ModConfig
	{
		public static BagConfig Instance;

		public override ConfigScope Mode => ConfigScope.ServerSide;

		// Storage units
		private const int minStorageUnitAmount = 0;
		private const int maxStorageUnitAmount = 99;
		
		[Increment(1)]
		[Range(minStorageUnitAmount, maxStorageUnitAmount)]
		[DefaultValue(2)]
		public int StorageUnitAmount { get; set; }

		// Storage heart
		[DefaultValue(true)]
		public bool GetStorageHeart;

		// Crafting Access
		[DefaultValue(true)]
		public bool GetCraftingAccess;

		// Crimtane storage upgrade
		private const int minCrimtaneAmount = 0;
		private const int maxCrimtaneAmount = 99;
		[Increment(1)]
		[Range(minCrimtaneAmount, maxCrimtaneAmount)]
		[DefaultValue(0)]
		public int CrimtaneAmount { get; set; }

		// Demonite Storage Upgrade
		private const int minDemoniteAmount = 0;
		private const int maxDemoniteAmount = 99;
		[Increment(1)]
		[Range(minDemoniteAmount, maxDemoniteAmount)]
		[DefaultValue(0)]
		public int DemoniteAmount { get; set; }

		// Hellstone Storage Upgrade
		private const int minHellstoneAmount = 0;
		private const int maxHellstoneAmount = 99;
		[Increment(1)]
		[Range(minHellstoneAmount, maxHellstoneAmount)]
		[DefaultValue(0)]
		public int HellstoneAmount { get; set; }

		// Hallowed Storage Upgrade
		private const int minHallowedAmount = 0;
		private const int maxHallowedAmount = 99;
		[Increment(1)]
		[Range(minHallowedAmount, maxHallowedAmount)]
		[DefaultValue(0)]
		public int HallowedAmount { get; set; }

		// Blue Chlorophyte Storage Upgrade
		private const int minChlorophyteAmount = 0;
		private const int maxChlorophyteAmount = 99;
		[Increment(1)]
		[Range(minChlorophyteAmount, maxChlorophyteAmount)]
		[DefaultValue(0)]
		public int ChlorophyteAmount { get; set; }

		// Luminite Storage Upgrade
		private const int minLuminiteAmount = 0;
		private const int maxLuminiteAmount = 99;
		[Increment(1)]
		[Range(minLuminiteAmount, maxLuminiteAmount)]
		[DefaultValue(0)]
		public int LuminiteAmount { get; set; }

		// Terra Storage Upgrade
		private const int minTerraAmount = 0;
		private const int maxTerraAmount = 99;
		[Increment(1)]
		[Range(minTerraAmount, maxTerraAmount)]
		[DefaultValue(0)]
		public int TerraAmount { get; set; }
		
		internal void ClampValues(StreamingContext context) {
			StorageUnitAmount = (int)Utils.Clamp(StorageUnitAmount, minStorageUnitAmount, maxStorageUnitAmount);
			CrimtaneAmount = (int)Utils.Clamp(CrimtaneAmount, minCrimtaneAmount, maxCrimtaneAmount);
			DemoniteAmount = (int)Utils.Clamp(DemoniteAmount, minDemoniteAmount, maxDemoniteAmount);
			HellstoneAmount = (int)Utils.Clamp(HellstoneAmount, minHellstoneAmount, maxHellstoneAmount);
			HallowedAmount = (int)Utils.Clamp(HallowedAmount, minHallowedAmount, maxHallowedAmount);
			ChlorophyteAmount = (int)Utils.Clamp(ChlorophyteAmount, minChlorophyteAmount, maxChlorophyteAmount);
			LuminiteAmount = (int)Utils.Clamp(LuminiteAmount, minLuminiteAmount, maxLuminiteAmount);
			TerraAmount = (int)Utils.Clamp(TerraAmount, minTerraAmount, maxTerraAmount);
		}
	}
}