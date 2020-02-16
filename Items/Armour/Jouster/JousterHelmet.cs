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
			Tooltip.SetDefault ("+4% increased movement speed");
		}

		public override void SetDefaults ()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice (0, 0, 74, 0);
			item.rare = ItemRarityID.Green;
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
