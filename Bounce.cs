using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace com.dragon_boat
{
	public class Bounce
	{

		Texture2D ballTexture,blockTexture,whiteRectangle;
		Rectangle ballBounds;
		Vector2 ballPosition;
		Vector2 ballVelocity;
		Rectangle blockBounds;
		Vector2 blockPosition;

		public float X
		{
			get;
			set;
		}

		public float Y
		{
			get;
			set;
		}
		public Bounce(GraphicsDevice graphicsDevice)
		{
			ballPosition = new Vector2(graphicsDevice.Viewport.Width / 2,
						   graphicsDevice.Viewport.Height * 0.20f);
			blockPosition = new Vector2(graphicsDevice.Viewport.Width / 2,
									   graphicsDevice.Viewport.Height * 0.85f);
			ballVelocity = new Vector2(0, 10);
			if (ballTexture == null)
			{
				using (var stream = TitleContainer.OpenStream("Content/boatForward.png"))
				{
					ballTexture = Texture2D.FromStream(graphicsDevice, stream);

				}
			}
			if (blockTexture == null)
			{
				using (var stream = TitleContainer.OpenStream("Content/boatForward.png"))
				{
blockTexture = Texture2D.FromStream(graphicsDevice, stream);

				}
			}
			//create rectangles based off the size of the textures
			ballBounds = new Rectangle((int)(ballPosition.X - ballTexture.Width / 2),
			(int)(ballPosition.Y - ballTexture.Height / 2), graphicsDevice.Viewport.Width/10, graphicsDevice.Viewport.Height/10);
			blockBounds = new Rectangle((int)(blockPosition.X - blockTexture.Width / 2),
			(int)(blockPosition.Y - blockTexture.Height / 2), graphicsDevice.Viewport.Width/10, graphicsDevice.Viewport.Height/10);
			whiteRectangle = new Texture2D(graphicsDevice, 1, 1);
whiteRectangle.SetData(new[] { Color.White });
		}
		public void CheckCollision(GraphicsDevice graphicsDevice)
		{
			if (ballBounds.Intersects(blockBounds) || !graphicsDevice.Viewport.Bounds.Contains(ballBounds))
			{

				//we have a simple collision!
				//if it has hit, swap the direction of the ball, and update it's position
				ballVelocity = -ballVelocity;
				ballPosition += ballVelocity;

			}

			else
			{

				//move the ball a bit
				ballPosition += ballVelocity;

			}

			//update bounding boxes
			ballBounds.X = (int)ballPosition.X;
			ballBounds.Y = (int)ballPosition.Y;

			blockBounds.X = (int)blockPosition.X;
			blockBounds.Y = (int)blockPosition.Y;
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			
			Color tintColor = Color.White;
			spriteBatch.Draw(whiteRectangle, ballBounds, tintColor);
			spriteBatch.Draw(whiteRectangle, blockBounds, tintColor);
			spriteBatch.Draw(blockTexture, blockBounds, tintColor);
			spriteBatch.Draw(ballTexture, ballBounds, tintColor);

		}

	}
}
