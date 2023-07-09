using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VexoVexing.Items.ninetyTwo;

namespace VexoVexing.Items.Susceptre
{
    public class SusceptreProjectile : ModProjectile
    {
        // Vector2 velocity = Main.MouseWorld;

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sussy laser");
        }

        public override void SetDefaults()
        {
            Projectile.friendly = true;
            Projectile.width = 32;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.height = 5;
            Projectile.timeLeft = 920;
            Projectile.penetrate = 5;
            Projectile.aiStyle = ProjAIStyleID.GemStaffBolt;
            Projectile.light = 2f;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
        }

        public override void AI()
        {
            Dust.NewDust(Projectile.position, 32, 32, DustID.Clentaminator_Red);
            Projectile.rotation = Projectile.velocity.ToRotation();
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Vector2 spawnVelocity = new Vector2(0, 0);
            Projectile.NewProjectile(Entity.GetSource_FromThis(), target.Center, spawnVelocity, ModContent.ProjectileType<AmongMinion>(), Projectile.damage, 0, Main.myPlayer);
        }
    }
}