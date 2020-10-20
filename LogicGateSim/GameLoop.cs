using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;

namespace LogicGateSim
{
    public class GameLoop : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        Switch switch1 = new Switch(new Rectangle(100, 100, 50, 50));
        Gate gate = new Gate(new Rectangle(400, 100, 50, 50), Gate.Type.Or);
        Gate gate1 = new Gate(new Rectangle(400, 200, 50, 50), Gate.Type.And);
        Gate gate2 = new Gate(new Rectangle(400, 300, 50, 50), Gate.Type.Not);
        Light light = new Light(new Rectangle(700, 100, 50, 50));

        public GameLoop()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("Font");
            gate.font = font;
            gate1.font = font;
            gate2.font = font;

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            Manager.Update();
            switch1.Update();
            gate.Update();
            gate1.Update();
            gate2.Update();
            light.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            switch1.Draw(spriteBatch);
            gate.Draw(spriteBatch);
            gate1.Draw(spriteBatch);
            gate2.Draw(spriteBatch);
            light.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}