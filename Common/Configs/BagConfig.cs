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
		private const int minStorageUnitAmount = 1;
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
		
		internal void ClampValues(StreamingContext context) {
			StorageUnitAmount = (int)Utils.Clamp(StorageUnitAmount, minStorageUnitAmount, maxStorageUnitAmount);
			CrimtaneAmount = (int)Utils.Clamp(CrimtaneAmount, minCrimtaneAmount, maxCrimtaneAmount);
		}
	}
}