﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Diagnostics;

namespace Colorful_Turret
{
    class Turret
    {
        Texture2D shipTexture;
        Texture2D projectileTexture;
        Vector2 shipOrigin;
        Vector2 shipPosition;
        Vector2 projectileSpeed;
        List<Projectile> projectile = new List<Projectile>();
        

        public Turret(Vector2 shipPosition, Texture2D shipTexture)
        {
            this.shipPosition = shipPosition;
            this.shipTexture = shipTexture;
            this.shipOrigin.X = shipTexture.Width / 2;
            this.shipOrigin.Y = shipTexture.Height / 2;
            this.projectileSpeed = new Vector2(1.0f);
            this.projectileTexture = Game1.projectileTexture;
        }

        private float direction;
        public void Update(MouseState mouseState, GraphicsDevice graphicsDevice)
        {
            mouseState = Mouse.GetState();
            float mouseX = mouseState.X;
            float mouseY = mouseState.Y;
            direction = (float)Math.Atan2(shipPosition.Y - mouseY, shipPosition.X - mouseX);
            if (InputHandler.NewMouseLeftClick())
            {
                Debug.WriteLine("Mouse clicked");

                projectile.Add(new Projectile(this.projectileTexture, this.shipPosition, this.projectileSpeed, (new Vector2(mouseX, mouseY)), direction)); 
            }
        }

        public float shipAngle () {
            return direction;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(shipTexture, shipPosition, null, Color.White, direction, shipOrigin, 1.0f, SpriteEffects.None, 0f);

            foreach(Projectile i in projectile){
                i.Draw(spriteBatch);
            }

        }
    }
}
