using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
namespace com.dragon_boat
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		Bounce boatF;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

		protected override void Initialize()
		{
			// TODO: Add your initialization logic here
			boatF = new Bounce(this.GraphicsDevice);


			base.Initialize();
		}
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);
		}


		protected override void Update(GameTime gameTime)
		{
			// For Mobile devices, this logic will close the Game when the Back button is pressed
			// Exit() is obsolete on iOS
#if !__IOS__ && !__TVOS__
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();
#endif

			// TODO: Add your update logic here
			//	boatF.X = boatF.X + 1;
			boatF.CheckCollision(this.GraphicsDevice);
			boatF.updateButton(this.GraphicsDevice);  
			base.Update(gameTime);
		}
		protected override void Draw(GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

			//TODO: Add your drawing code here
			spriteBatch.Begin();
			//Vector2 topLeftOfSprite = new Vector2(50, 50);
			//Color tintColor = Color.White;
			//spriteBatch.Draw(boatForward, topLeftOfSprite, tintColor);
			boatF.Draw(spriteBatch); 
			spriteBatch.End();
			base.Draw(gameTime);
		}





	}
}
