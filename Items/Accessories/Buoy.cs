﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using System;
using PixelItems.Utils;

namespace PixelItems.Items.Accessories
{
	[AutoloadEquip (EquipType.Waist)]
	public class Buoy : ModItem
	{
		public override bool Autoload (ref string name)
		{
			IL.Terraria.Player.Update += PlayerUpdateHook;
			return base.Autoload (ref name);
		}

		private void PlayerUpdateHook (ILContext il)
		{
			ILCursor cursor = new ILCursor (il);

			ILLabel noBuoyLabel = il.DefineLabel ();

			if (!cursor.TryGotoNext (MoveType.After, i => i.MatchStfld<Player> (nameof (Player.maxFallSpeed)), i => i.MatchLdarg (0), i => i.MatchLdfld<Entity> (nameof (Entity.wet)), i => i.Match (OpCodes.Brfalse_S)))
				throw new InvalidOperationException ($"{nameof (PixelItems)} IL editing failed: {nameof (Buoy.PlayerUpdateHook)} could not find redirect point.");

			cursor.Previous.Operand = noBuoyLabel;

			if (!cursor.TryGotoNext (MoveType.AfterLabel, i => i.MatchLdarg (0), i => i.MatchLdfld<Player> (nameof (Player.vortexDebuff))))
				throw new InvalidOperationException ($"{nameof (PixelItems)} IL editing failed: {nameof (Buoy.PlayerUpdateHook)} could not find entry point.");

			cursor.Emit (OpCodes.Ldarg_0);
			cursor.EmitDelegate<Func<Player, bool>> (player => this.isEquippedOn (player));
			cursor.Emit (OpCodes.Brfalse, noBuoyLabel);

			cursor.Emit (OpCodes.Ldarg_0);
			cursor.Emit (OpCodes.Ldarg_0);
			cursor.Emit<Player> (OpCodes.Ldfld, nameof (Player.gravity));
			cursor.Emit (OpCodes.Ldc_I4_M1);
			cursor.Emit (OpCodes.Mul);

			cursor.Emit<Player> (OpCodes.Stfld, nameof (Player.gravity));

			cursor.MarkLabel (noBuoyLabel);
		}

		public override void SetStaticDefaults ()
		{
			DisplayName.SetDefault ("Float Ring");
			Tooltip.SetDefault ("This highly buoyant ring lets you float in liquids.");
		}

		public override void SetDefaults ()
		{
			item.width = 22;
			item.height = 20;
			item.value = 10000;
			item.rare = 2;
			item.accessory = true;
		}

		public override void AddRecipes ()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient (ItemID.LifePreserver);
			recipe.AddIngredient (ItemID.ShinyRedBalloon);
			recipe.AddTile (TileID.TinkerersWorkbench);
			recipe.SetResult (this);
			recipe.AddRecipe ();
		}
	}
}