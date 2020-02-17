using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace PixelItems
{
	public class PixelPlayer : ModPlayer
	{
		public bool hasMirrorShield = false;
		public int mirrorShieldCooldownFrames = 0;

		private int lastMirrorShieldProc = 0;

		public override void ResetEffects ()
		{
			hasMirrorShield = false;
			mirrorShieldCooldownFrames = int.MaxValue;
		}

		public override bool CanBeHitByProjectile (Projectile proj)
		{
			if (hasMirrorShield && PixelItems.frameCount - lastMirrorShieldProc > mirrorShieldCooldownFrames && proj.Colliding (player.Hitbox, proj.Hitbox))
			{
				lastMirrorShieldProc = PixelItems.frameCount;
				reflectProjectile (proj);
				return false;
			}
			else
				return base.CanBeHitByProjectile (proj);
		}

		// Using https://gamedev.stackexchange.com/a/25582 to determine which axes to reflect projectile in.
		private void reflectProjectile (Projectile projectile)
		{
			projectile.hostile = false;
			projectile.friendly = true;

			Vector2 projectileCenter = projectile.Center - projectile.velocity;
			Vector2 oldVelocity = projectile.velocity * -1;
			Vector2 ourBottomLeft = player.BottomLeft;
			float difference = projectileCenter.Y - ourBottomLeft.Y;

			bool ab = difference * player.width > (projectileCenter.X - ourBottomLeft.X) * player.height;
			bool ad = difference * player.width > (player.TopRight.X - projectileCenter.X) * player.height;

			if (ab == ad)
				projectile.velocity.Y *= -1;
			else
				projectile.velocity.X *= -1;

			Vector2 predictedPosition = projectile.Center + projectile.velocity;

			if (predictedPosition.X > ourBottomLeft.X
			 && predictedPosition.X < ourBottomLeft.X + player.width
			 && predictedPosition.Y < ourBottomLeft.Y
			 && predictedPosition.Y > ourBottomLeft.Y - player.height)
				projectile.velocity *= -1;

			Main.PlaySound (SoundID.Item, projectile.position, 30);

			for (int i = 0; i < 2; ++i)
			{
				int dustIndex = Dust.NewDust (projectile.Center, 0, 0, 45, oldVelocity.X, oldVelocity.Y, 255, default, Main.rand.Next (20, 26) * 0.1f);
				Main.dust [dustIndex].noLight = true;
				Main.dust [dustIndex].noGravity = true;
				Main.dust [dustIndex].velocity *= 0.5f;
			}

			for (int i = 0; i < 2; ++i)
			{
				int dustIndex = Dust.NewDust (projectile.Center, 0, 0, 45, projectile.velocity.X, projectile.velocity.Y, 255, default, Main.rand.Next (20, 26) * 0.1f);
				Main.dust [dustIndex].noLight = true;
				Main.dust [dustIndex].noGravity = true;
				Main.dust [dustIndex].velocity *= 0.5f;
			}
		}
	}
}
