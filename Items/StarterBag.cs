// Add MagicStorage usage
using MagicStorage;
using MagicStorage.Items;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace MSStarterBag.Items
{
	// Create the StarterBag class, derived from ModItem and ILocalizedModType
	public class StarterBag : ModItem, ILocalizedModType
	{
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

		// Change the loot of the starter bag
		public override void ModifyItemLoot(ItemLoot itemLoot) {
			// Add the StorageHeart
			itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<StorageHeart>()));
			// Add the CraftingAccess
			itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<CraftingAccess>()));
			// Add the StorageUnit
			itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<StorageUnit>()));
		}
	}
}