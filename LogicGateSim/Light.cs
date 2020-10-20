using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicGateSim
{
    class Light
    {
        bool value = false;
        Rectangle collider;
        InputPin inputPin = new InputPin(new Rectangle(0, 0, 20, 20));
        Draggable draggable = new Draggable();

        public Light(Rectangle collider)
        {
            this.collider = collider;
        }
        public void Update()
        {
            inputPin.collider.Location = collider.Location - new Point(25, -collider.Height / 2 + inputPin.collider.Height / 2);
            value = inputPin.value;
            inputPin.Update();

            collider.Location = draggable.UpdatePosition(collider);
        }

        public void Draw(SpriteBatch sb)
        {
            var color = value ? Color.Yellow : Color.White;
            sb.DrawRectangle(collider, color, 5);
            inputPin.Draw(sb);
        }
    }
}
