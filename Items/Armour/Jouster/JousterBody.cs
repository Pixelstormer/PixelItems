using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PixelItems.Items.Armour.Jouster
{
	[AutoloadEquip (EquipType.Body)]
	public class JousterBody : ModItem
	{
		public override void SetStaticDefaults ()
		{
			Tooltip.SetDefault ("Jouster breastplate." +
								"\nIncreased movement speed." +
								"\nSet bonus: Grants extra bonuses while mounted.");
		}

		public override void SetDefaults ()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.defense = 30;
		}

		public override bool IsArmorSet (Item head, Item body, Item legs)
		{
			return head.type == ModContent.ItemType<JousterHelmet> () && legs.type == ModContent.ItemType<JousterLegs> ();
		}

		public override void UpdateArmorSet (Player player)
		{
			if (player.mount.Active)
				player.statDefense += 125;

			player.setBonus = "+125 defence while mounted.";
		}

		public override void UpdateEquip (Player player)
		{
			player.moveSpeed += 0.5f;
		}

		public override void AddRecipes ()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient (ItemID.GladiatorBreastplate);
			recipe.AddTile (TileID.WorkBenches);
			recipe.SetResult (this);
			recipe.AddRecipe ();
		}
	}
}
