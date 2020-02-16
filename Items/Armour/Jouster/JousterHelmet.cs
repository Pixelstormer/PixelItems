using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PixelItems.Items.Armour.Jouster
{
	[AutoloadEquip (EquipType.Head)]
	public class JousterHelmet : ModItem
	{
		public override void SetStaticDefaults ()
		{
			Tooltip.SetDefault ("+4% Increased Movement Speed");
		}

		public override void SetDefaults ()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.defense = 5;
		}

		public override void UpdateEquip (Player player)
		{
			player.moveSpeed += 0.04f;
		}

		public override void AddRecipes ()
		{
			ModRecipe recipe = new ModRecipe (mod);
			recipe.AddIngredient (ItemID.GladiatorHelmet);
			recipe.AddIngredient (ItemID.FossilOre, 20);
			recipe.AddTile (TileID.Anvils);
			recipe.SetResult (this);
			recipe.AddRecipe ();
		}
	}
}
