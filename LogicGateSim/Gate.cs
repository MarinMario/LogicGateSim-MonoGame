using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;

namespace LogicGateSim
{
    class Gate
    {
        public InputPin inputPin1 = new InputPin(new Rectangle(0, 0, 20, 20));
        public InputPin inputPin2 = new InputPin(new Rectangle(0, 0, 20, 20));
        public OutputPin outputPin = new OutputPin(new Rectangle(0, 0, 20, 20));
        public Rectangle collider;
        public SpriteFont font;
        Draggable draggable = new Draggable();
        public enum Type { And, Or, Not }
        public Type type;

        public Gate(Rectangle collider, Type type)
        {
            this.collider = collider;
            this.type = type;
        }

        public void Update()
        {
            inputPin1.collider.Location = collider.Location - new Point(25, inputPin1.collider.Height * 2 / 3 - collider.Height / 3);
            inputPin2.collider.Location = collider.Location - new Point(25, -inputPin2.collider.Height * 2 / 3 - collider.Height / 3);
            outputPin.collider.Location = collider.Location + new Point(collider.Width + 5, collider.Height / 2 - outputPin.collider.Height / 2);

            inputPin1.Update();
            inputPin2.Update();
            outputPin.Update();
            collider.Location = draggable.UpdatePosition(collider);

            outputPin.value = type switch
            {
                Type.And => inputPin1.value && inputPin2.value,
                Type.Or => inputPin1.value || inputPin2.value,
                Type.Not => !inputPin1.value,
                _ => false
            };
        }

        public void Draw(SpriteBatch sb)
        {
            sb.DrawRectangle(collider, Color.White, 5);
            sb.DrawString(font, type.ToString(), new Vector2(collider.X + 10, collider.Y + 10), Color.White);
            inputPin1.Draw(sb);
            inputPin2.Draw(sb);
            outputPin.Draw(sb);
        }

    }
}
