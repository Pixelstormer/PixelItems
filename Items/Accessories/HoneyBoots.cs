using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PixelItems.Items.Accessories
{
	[AutoloadEquip (EquipType.Shoes)]
	public class HoneyBoots : ModItem
	{
		public override void SetStaticDefaults ()
		{
			Tooltip.SetDefault ("These boots let you walk on honey without being slowed down.");
		}

		public override void SetDefaults ()
		{
			item.width = 22;
			item.height = 20;
			item.value = 10000;
			item.rare = 2;
			item.accessory = true;
		}

		public override void UpdateAccessory (Player player, bool hideVisual)
		{
			player.sticky = false;
		}

		public override void AddRecipes ()
		{
			ModRecipe recipe = new ModRecipe (mod);
			recipe.AddIngredient (ItemID.IceSkates);
			recipe.AddIngredient (ItemID.WaterWalkingBoots);
			recipe.AddTile (TileID.TinkerersWorkbench);
			recipe.SetResult (this);
			recipe.AddRecipe ();
		}
	}
}
