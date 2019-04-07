using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreakerM
{
    public class Sprite
    {
        public Texture2D Image;
        public Vector2 Position;
        public Vector2 Speed;
        public Color Tint;
        public Rectangle Hitbox
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, Image.Width, Image.Height);
            }
        }

        public Sprite(Texture2D image, Vector2 position, Vector2 speed, Color Tint)
        {
            this.Image = image;
            this.Position = position;
            this.Speed = speed;
            this.Tint = Tint;
        }



        public void Draw(SpriteBatch batch)
        {
            batch.Draw(Image, Position, Tint);
        }
    }
}
