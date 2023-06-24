using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace VexoVexing.Items.WaterArrow
{
    public class WaterArrowProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Water Arrow");
        }

        public override void SetDefaults()
        {
            Projectile.aiStyle = ProjAIStyleID.Arrow;
            Projectile.width = 1;
            Projectile.height = 1;
            Projectile.friendly = true;
            Projectile.stepSpeed = 92;
            Projectile.penetrate = 1;
        }

        public override void AI()
        {
            Dust.NewDust(Projectile.Center, 5, 5, DustID.Water);
        }

        public override void OnSpawn(IEntitySource source)
        {
            Projectile.velocity *= 1.5f;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            int projectiles = 6;
            for (int i = 0; i < 92; i++)
            {
                Dust.NewDust(Projectile.Center, 5, 5, DustID.Water);
            }
            Vector2 newVelocity = new();
            for (int angle = 180 / projectiles + 1; angle <= 180; angle += 180 / (projectiles + 1))
            {
                newVelocity.X = (float)Math.Cos(ToRadians(angle + Main.rand.Next(20) - 10)); //  + Main.rand.Next(20) - 10
                newVelocity.Y = -(float)Math.Sin(ToRadians(angle + Main.rand.Next(20) - 10));
                newVelocity *= (float)(oldVelocity.Length() / 2.5);
                Projectile.NewProjectile(Entity.GetSource_FromThis(), Projectile.Center, newVelocity, ModContent.ProjectileType<DropletProjectile>(), Projectile.damage, Projectile.knockBack, Owner: Main.myPlayer);
            }
            return true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            // Maximum of 359. 360 crashes the game
            int projectiles = 12;
            Vector2 newVelocity = new();
            for (int i = 360 / projectiles + 1; i <= 360; i += 360 / (projectiles + 1))
            {
                newVelocity.X = (float)Math.Cos(ToRadians(i));
                newVelocity.Y = -(float)Math.Sin(ToRadians(i));
                newVelocity *= (float)(Projectile.velocity.Length() / 2.5);
                Projectile.NewProjectile(Entity.GetSource_FromThis(), Projectile.Center, newVelocity, ModContent.ProjectileType<DropletProjectile>(), Projectile.damage, Projectile.knockBack, Owner: Main.myPlayer);
            }
        }

        public static double ToRadians(int degrees)
        {
            return degrees * Math.PI / 180;
        }
    }
}
