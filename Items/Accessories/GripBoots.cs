using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using System;
using PixelItems.Utils;

namespace PixelItems.Items.Accessories
{
	[AutoloadEquip (EquipType.Shoes)]
	public class GripBoots : ModItem
	{
		public override bool Autoload (ref string name)
		{
			IL.Terraria.Player.TryBouncingBlocks += HookBounceCheck;
			return base.Autoload (ref name);
		}

		private void HookBounceCheck (ILContext il)
		{
			ILCursor cursor = new ILCursor (il);
			ILLabel continueMethodLabel = il.DefineLabel ();

			cursor.Emit (OpCodes.Ldarg_0);
			cursor.EmitDelegate<Func<Player, bool>> (player => this.isEquippedOn (player));
			cursor.Emit (OpCodes.Brfalse, continueMethodLabel);
			cursor.Emit (OpCodes.Ret);
			cursor.MarkLabel (continueMethodLabel);
		}

		public override void SetStaticDefaults ()
		{
			Tooltip.SetDefault ("Ice is no longer slippery, and will not break when you fall on it." +
								"\nPink Slime is no longer bouncy.");
		}

		public override void SetDefaults ()
		{
			item.width = 16;
			item.height = 24;
			item.value = Item.sellPrice (0, 3, 0, 0);
			item.rare = ItemRarityID.Green;
			item.accessory = true;
		}

		public override void UpdateAccessory (Player player, bool hideVisual)
		{
			player.slippy = false;
			player.slippy2 = false;
			player.iceSkate = true;
		}

		public override void AddRecipes ()
		{
			ModRecipe recipe = new ModRecipe (mod);
			recipe.AddIngredient (ItemID.IceSkates);
			recipe.AddIngredient (ItemID.ShoeSpikes);
			recipe.AddTile (TileID.TinkerersWorkbench);
			recipe.SetResult (this);
			recipe.AddRecipe ();
		}
	}
}
