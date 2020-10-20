using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;

namespace LogicGateSim
{
    static class MouseEvent
    {
        static public bool Over(Rectangle collider)
        {
            return collider.Contains(Mouse.GetState().Position);
        }

        static bool leftClickPressed = false;
        static public bool LeftClick(Rectangle collider)
        {
            if (!leftClickPressed && LeftClickDown(collider))
            {
                leftClickPressed = true;
                return LeftClickDown(collider);
            }

            if (Mouse.GetState().LeftButton == ButtonState.Released)
                leftClickPressed = false;

            return false;
        }

        static public bool LeftClickDown(Rectangle collider)
        {
            return Over(collider) && Mouse.GetState().LeftButton == ButtonState.Pressed;
        }

        static public bool RightClickDown(Rectangle collider)
        {
            return Over(collider) && Mouse.GetState().RightButton == ButtonState.Pressed;
        }
    }
}
