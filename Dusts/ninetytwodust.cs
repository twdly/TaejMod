using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace VexoVexing.Dusts
{
    public class ninetytwodust : ModDust
    {
        int hue;
        int vexo;
        Vector2 acceleration;
        static double angle;

        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.frame = new Rectangle(0, 0, 40, 40);
            angle = Main.rand.NextDouble() * 2 * System.Math.PI;
            dust.velocity = new Vector2((float)Math.Sin(angle) * 5, (float)Math.Cos(angle) * 5);
            dust.noLight = true;
            //If our texture had 2 different dust on top of each other (a 30x60 pixel image), we might do this:
            //dust.frame = new Rectangle(0, Main.rand.Next(2) * 30, 30, 30);
        }

        public override bool Update(Dust dust)
        {
            // dust.velocity += acceleration;
            // if (Main.rand.NextBool(120))
            // {
            //     hue += 1;
            //     dust.color = new Color(0, 0, hue % 256);
            //     acceleration = Main.rand.NextVector2Unit();
            // }
            dust.position += dust.velocity;
            dust.scale += 0.01f;
            if (dust.scale < 0.75f)
            {
                dust.active = false;
            }

            Lighting.AddLight(dust.position, 1, 1, 1);

            int vexo = Main.rand.Next(2);


            return false;
        }

        //     public override Color? GetAlpha(Dust dust, Color lightColor)
        //     {
        //         return new Color(red, green, blue);
        //     }
    }
}