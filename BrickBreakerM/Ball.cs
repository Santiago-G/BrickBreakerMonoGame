using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreakerM
{
    class Ball : Sprite
    {

        public Ball(Texture2D image, Vector2 position, Vector2 speed, Color Tint) : base(image, position, speed, Tint)
        {

        }

        public void Update(Viewport screen)
        {

            Position.X += Speed.X;
            Position.Y += Speed.Y;

            if (Position.X <= 0)
            {
                Speed.X *= -1;
            }

            else if (Position.X >= screen.Width - Image.Width)
            {
                Speed.X *= -1;
            }

            else if (Position.Y >= screen.Height - Image.Width)
            {
                Speed.Y *= -1;
            }

            else if (Position.Y <= 0)
            {
                Speed.Y *= -1;
            }

        }

    }
}
