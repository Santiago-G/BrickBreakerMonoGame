using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreakerM
{
    class Paddle : Sprite
    {

        public Paddle(Texture2D image, Vector2 position, Vector2 speed, Color Tint) : base(image, position, speed, Tint)
        {

        }

        public void Update(Viewport screen, KeyboardState ks)
        {

            if (ks.IsKeyDown(Keys.Right))
            {
                MoveRight(1500);
            }

            else if (ks.IsKeyDown(Keys.Left))
            {
                MoveLeft();
            }

        }

        private void MoveRight(int screenWidth)
        {
            if (Position.X + Image.Width < screenWidth)
            {
                Position = new Vector2(Position.X + Speed.X, Position.Y);
            }
        }

        private void MoveLeft()
        {
            if (Position.X > 0)
            {
                Position = new Vector2(Position.X - Speed.X, Position.Y);
            }
        }

    }
}
