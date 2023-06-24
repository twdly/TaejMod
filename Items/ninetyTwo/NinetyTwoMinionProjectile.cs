using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VexoVexing.Dusts;

namespace VexoVexing.Items.ninetyTwo
{
    public class NinetyTwoMinionProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ninety Two");
            Main.projPet[Projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.width = 128;
            Projectile.height = 64;
            Projectile.aiStyle = ProjAIStyleID.FlaironBubble;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Summon;
            Projectile.minion = true;
            Projectile.minionSlots = 0f;
            Projectile.penetrate = -1;
        }

        public override bool? CanCutTiles()
        {
            return true;
        }

        public override bool MinionContactDamage()
        {
            return true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.life = 0;
        }

        public override void AI()
        {
            // Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Clentaminator_Cyan, Scale: 10);
            // Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Clentaminator_Cyan, Scale: 10);
            // Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Clentaminator_Green, Scale: 10);
            // Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Clentaminator_Blue, Scale: 10);
            // Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Clentaminator_Cyan, Scale: 10);
            if (Main.rand.NextBool(5))
            {
                // Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<ninetytwodust>());
                Dust.NewDustPerfect(Projectile.position, ModContent.DustType<ninetytwodust>());
            }

            Player player = Main.player[Projectile.owner];
            if (player.dead || !player.active)
            {
                player.ClearBuff(ModContent.BuffType<NinetyTwoMinionBuff>());
            }
            if (player.HasBuff(ModContent.BuffType<NinetyTwoMinionBuff>()))
            {
                Projectile.timeLeft = 2;
            }

            // if (player.HasItem(ItemID.GenderChangePotion))
            // {
            //     Projectile.hostile = true;
            // }
            // else
            // {
            //     Projectile.hostile = false;
            // }
        }
    }
}