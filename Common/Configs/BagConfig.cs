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

		private const int minStorageUnitAmount = 1;
		private const int maxStorageUnitAmount = 10;
		
		[Increment(1)]
		[Range(minStorageUnitAmount, maxStorageUnitAmount)]
		[DefaultValue(2)]
		[ReloadRequired]
		public int StorageUnitAmount { get; set; }

		internal void ClampValues(StreamingContext context) {
			StorageUnitAmount = (int)Utils.Clamp(StorageUnitAmount, minStorageUnitAmount, maxStorageUnitAmount);
		}
	}
}