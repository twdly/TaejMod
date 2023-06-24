using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace VexoVexing.Items.ninetyTwo
{
    public class ninetyTwo : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ninety Two"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("This is a little bit of a roiling.");
            ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 9292;
            Item.useStyle = ItemUseStyleID.Guitar;
            Item.mana = 5;
            Item.DamageType = DamageClass.Summon;
            Item.width = 92;
            Item.height = 92;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.value = 920000;
            Item.rare = 10;
            Item.UseSound = SoundID.Item92;
            Item.autoReuse = false;
            Item.shoot = ModContent.ProjectileType<NinetyTwoMinionProjectile>();
            Item.noMelee = true;
            Item.buffType = ModContent.BuffType<NinetyTwoMinionBuff>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DirtBlock, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
            recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.GenderChangePotion, 92);
            recipe.AddTile(TileID.Grass);
            recipe.Register();
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            player.AddBuff(Item.buffType, 2, true);
            position = Main.MouseWorld;
            return true;
        }
    }
}
