using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PixelItems.Items.Accessories
{
	[AutoloadEquip (EquipType.Shield)]
	public class MirrorShield : ModItem
	{
		public int cooldownFrames;

		public override void SetStaticDefaults ()
		{
			DisplayName.SetDefault ("Mirror Shield");
			Tooltip.SetDefault ("Allows the holder to reflect projectiles." +
								"\nHas a two second cooldown.");
		}

		public override void SetDefaults ()
		{
			item.width = 30;
			item.height = 30;
			item.value = Item.sellPrice (0, 1, 20, 0);
			item.rare = ItemRarityID.Green;
			item.accessory = true;

			cooldownFrames = 120;
		}

		public override void AddRecipes ()
		{
			ModRecipe recipe = new ModRecipe (mod);
			recipe.AddIngredient (ItemID.PaladinsShield);
			recipe.AddIngredient (ItemID.PocketMirror);
			recipe.AddTile (TileID.TinkerersWorkbench);
			recipe.SetResult (this);
			recipe.AddRecipe ();
		}

		public override void UpdateAccessory (Player player, bool hideVisual)
		{
			PixelPlayer pixelPlayer = player.GetModPlayer<PixelPlayer> ();
			pixelPlayer.hasMirrorShield = true;
			pixelPlayer.mirrorShieldCooldownFrames = cooldownFrames;
		}
	}
}
