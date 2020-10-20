using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicGateSim
{
    class Switch
    {
        bool value = false;
        public Rectangle collider;
        public OutputPin outputPin = new OutputPin(new Rectangle(0, 0, 20, 20));
        Draggable draggable = new Draggable();

        public Switch(Rectangle collider)
        {
            this.collider = collider;
        }

        public void Update()
        {
            outputPin.collider.Location = collider.Location + new Point(collider.Width + 5, collider.Height / 2 - outputPin.collider.Height / 2);
            outputPin.value = value;
            outputPin.Update();

            collider.Location = draggable.UpdatePosition(collider);

            if (MouseEvent.LeftClick(collider))
                Toggle();
        }

        public void Draw(SpriteBatch sb)
        {
            var color = value ? Color.White : Color.Black;
            sb.DrawRectangle(collider, color, 5);
            outputPin.Draw(sb);
        }
        
        public void Toggle()
        {
            value = !value;
        }
    }
}
