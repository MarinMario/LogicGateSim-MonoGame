using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicGateSim
{
    class Draggable
    {
        bool followMouse = false;

        public Point UpdatePosition(Rectangle collider)
        {
            if (MouseEvent.LeftClickDown(collider))
                followMouse = true;
            if (Mouse.GetState().LeftButton == ButtonState.Released)
                followMouse = false;

            if (followMouse)
                return Mouse.GetState().Position - new Point(collider.Width / 2, collider.Height / 2);
            return collider.Location;
        }
    }
}
