using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Shapes;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicGateSim
{
    class InputPin
    {
        public bool value = false;
        public OutputPin outputPin;
        public Rectangle collider;

        public InputPin(Rectangle collider)
        {
            this.collider = collider;
        }

        public void Update()
        {
            value = outputPin != null && outputPin.value;

            if (MouseEvent.LeftClick(collider))
                Manager.LastInputPin = this;
        }

        public void Draw(SpriteBatch sb)
        {
            var color = value ? Color.Yellow : Color.White;

            sb.DrawRectangle(collider, color, 5);
            if (outputPin != null)
                sb.DrawLine(collider.X, collider.Y + 10, outputPin.collider.X, outputPin.collider.Y + 10, color, 10);
        }
    }
}
