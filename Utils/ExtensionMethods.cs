using Terraria;
using Terraria.ModLoader;

namespace PixelItems.Utils
{
	public static class ExtensionMethods
	{
		/// <summary>
		/// Determines whether or not a given <see cref="Player"/> has this <see cref="ModItem"/> equipped or not, not counting vanity slots.
		/// </summary>
		/// <typeparam name="TItem">The type of the <see cref="ModItem"/> to check for.</typeparam>
		/// <param name="modItem">The <see cref="ModItem"/> to check for.</param>
		/// <param name="player">The <see cref="Player"/> to check.</param>
		/// <returns>Whether or not the given <see cref="Player"/> has the given <see cref="ModItem"/> equipped.</returns>
		public static bool isEquippedOn<TItem> (this TItem modItem, Player player) where TItem : ModItem
		{
			for (int i = 3; i < 8 + player.extraAccessorySlots; ++i)
			{
				Item otherItem = player.armor[i];
				if (modItem.item.IsTheSameAs (otherItem) || otherItem.modItem is TItem)
					return true;
			}

			return false;
		}

		/// <summary>
		/// Gets the full name for a given recipe group shorthand, according to the "<c>ModName:GroupName</c>" convention described by
		/// <a href="https://github.com/tModLoader/tModLoader/wiki/Intermediate-Recipes#new-recipegroups">the tModLoader wiki</a>.
		/// </summary>
		/// <param name="recipeGroupName">The recipe group shorthand name to get the full name of.</param>
		/// <returns>The full name of the given recipe group shorthand, e.g. to use for <see cref="ModRecipe.AddRecipeGroup(string, int)"/>.</returns>
		public static string fullName (this PixelItems.RecipeGroupName recipeGroupName)
		{
			return nameof (PixelItems) + ':' + recipeGroupName.ToString ();
		}
	}
}
