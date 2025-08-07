// Add MagicStorage usage
using MagicStorage;
using MagicStorage.Items;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using MSStarterBag.Common.Configs;

namespace MSStarterBag.Items
{
	// Create the StarterBag class, derived from ModItem and ILocalizedModType
	public class StarterBag : ModItem, ILocalizedModType
	{
		// A list of the items to give the player
		List<Item> storage = new();

		// Static default values
		public override void SetStaticDefaults() {
            		Item.ResearchUnlockCount = 0;
        	}

		// Default values
		public override void SetDefaults() {
            		Item.width = 24;
            		Item.height = 24;
            		Item.consumable = true;
            		Item.rare = ItemRarityID.Blue;
        	}

		// You can right click the item
        public override bool CanRightClick() {
			return true;
		}

		// Function to add configured yes/no items to the list
		private void AddBoolToList(bool instance, int item) {
			if (instance) {
				storage.Add(new(item));
			}
		}

		// Function to add configured amounts of items to the list
		private void AddIntToList(int instance, int item) {
			if (instance > 0) {
				for (int i = 0; i < instance; i++) {
					storage.Add(new(item));
				}
			}
		}

		// When you right click the item
		public override void RightClick(Player player) {
			// Check the config if the player should get a Storage Heart and add to the list
			AddBoolToList(BagConfig.Instance.GetStorageHeart, ModContent.ItemType<StorageHeart>());

			// Check the config if the player should get a Crafting Interface and add to the list
			AddBoolToList(BagConfig.Instance.GetCraftingAccess, ModContent.ItemType<CraftingAccess>());

			// Add the configured amounts of Storage Units to the list
			AddIntToList(BagConfig.Instance.StorageUnitAmount, ModContent.ItemType<StorageUnit>());

			// Add the configured amounts of Crimtane Storage Upgrades to the list
			AddIntToList(BagConfig.Instance.CrimtaneAmount, ModContent.ItemType<UpgradeCrimtane>());

			// Add the configured amounts of Demonite Storage Upgrades to the list
			AddIntToList(BagConfig.Instance.DemoniteAmount, ModContent.ItemType<UpgradeDemonite>());

			// Add the configured amounts of Hellstone Storage Upgrades to the list
			AddIntToList(BagConfig.Instance.HellstoneAmount, ModContent.ItemType<UpgradeHellstone>());

			// Add the configured amounts of Hallowed Storage Upgrades to the list
			AddIntToList(BagConfig.Instance.HallowedAmount, ModContent.ItemType<UpgradeHallowed>());

			// Add the configured amounts of Blue Chlorophyte Storage Upgrades to the list
			AddIntToList(BagConfig.Instance.ChlorophyteAmount, ModContent.ItemType<UpgradeBlueChlorophyte>());

			// Add the configured amounts of Luminite Storage Upgrades to the list
			AddIntToList(BagConfig.Instance.LuminiteAmount, ModContent.ItemType<UpgradeLuminite>());

			// Add the configured amounts of Terra Storage Upgrades to the list
			AddIntToList(BagConfig.Instance.TerraAmount, ModContent.ItemType<UpgradeTerra>());

			// Add the configured amounts of Shadow Diamonds to the list
			AddIntToList(BagConfig.Instance.ShadowDiamondAmount, ModContent.ItemType<ShadowDiamond>());

			// Add the configured amounts of Storage Components to the list
			AddIntToList(BagConfig.Instance.ComponentAmount, ModContent.ItemType<StorageComponent>());

			// Add all the items from the list
			foreach (Item item in storage) player.QuickSpawnItem(Item.GetSource_Loot(), item);

			// Remove the 'bag' item
			Item.TurnToAir();
		}
	}
}