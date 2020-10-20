using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicGateSim
{
    class OutputPin
    {
        public bool value = false;
        public Rectangle collider;

        public OutputPin(Rectangle collider)
        {
            this.collider = collider;
        }

        public void Update()
        {
            if (MouseEvent.LeftClick(collider))
                Manager.LastOutputPin = this;
        }

        public void Draw(SpriteBatch sb)
        {
            var color = value ? Color.Yellow : Color.White;
            sb.DrawRectangle(collider, color, 5);
        }
    }
}
