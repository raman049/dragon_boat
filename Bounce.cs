using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace com.dragon_boat
{
	public class Bounce
	{
		Texture2D ballTexture, blockTexture, whiteRectangle;
		Rectangle ballBounds, boatRect;
		Vector2 ballPosition, ballVelocity, boatPostion;
		Button button1, button2;

SpriteFont font;
 	
		public float X { get; set; }
		public float Y { get; set; }


		public Bounce(GraphicsDevice graphicsDevice)
		{


			ballPosition = new Vector2(graphicsDevice.Viewport.Width / 2,
						   graphicsDevice.Viewport.Height * 0.20f);
			boatPostion = new Vector2(graphicsDevice.Viewport.Width / 2,
									   graphicsDevice.Viewport.Height * 0.85f);
			ballVelocity = new Vector2(4, 10);
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
			(int)(ballPosition.Y - ballTexture.Height / 2), graphicsDevice.Viewport.Width / 10, graphicsDevice.Viewport.Height / 10);
			boatRect = new Rectangle((int)(boatPostion.X - blockTexture.Width / 2),
			(int)(boatPostion.Y - blockTexture.Height / 2), graphicsDevice.Viewport.Width / 10, graphicsDevice.Viewport.Height / 10);
			whiteRectangle = new Texture2D(graphicsDevice, 1, 1);
			whiteRectangle.SetData(new[] { Color.White });


			button1 = new Button(graphicsDevice, new Rectangle(0, 0, graphicsDevice.Viewport.Width / 2, graphicsDevice.Viewport.Height));
			button2 = new Button(graphicsDevice, new Rectangle(graphicsDevice.Viewport.Width / 2, 0, graphicsDevice.Viewport.Width / 2, graphicsDevice.Viewport.Height));

		}
		public void LoadContent(ContentManager content)
		{
			font = content.Load<SpriteFont>("AlphaWoodFont");
		}



		public void CheckCollision(GraphicsDevice graphicsDevice)
		{
			if (ballBounds.Intersects(boatRect) || !graphicsDevice.Viewport.Bounds.Contains(ballBounds))
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

			boatRect.X = (int)boatPostion.X;
			boatRect.Y = (int)boatPostion.Y;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			Color tintColor = Color.White;
			//spriteBatch.Draw(whiteRectangle, ballBounds, tintColor);
			//spriteBatch.Draw(whiteRectangle, boatRect, tintColor);
			spriteBatch.Draw(blockTexture, boatRect, tintColor);
		//	spriteBatch.DrawString( font, "text to print", boatPostion, Color.Red);
			//spriteBatch.Draw(ballTexture, ballBounds, tintColor);
			//button1.Draw(spriteBatch);
			//button2.Draw(spriteBatch);
			spriteBatch.DrawString(font, "text to 23423423423423423 print", new Vector2(40,40), Color.Red);
		}

		public void moveRight()
		{
			boatPostion.X += 10;
			boatPostion.Y -= 20;
			//ballPosition.X += 20;
		}
		public void moveLeft()
		{
			boatPostion.X -= 10;
			boatPostion.Y -= 20;
			//ballPosition.X -= 20;
		}
		public void moveDown()
		{
			boatPostion.Y -= (int)0.2;
		}
		TouchCollection touchCollection;
		public void updateButton(GraphicsDevice graphicsDevice)
		{
			touchCollection = TouchPanel.GetState();
			if (button1.touchSelect(touchCollection))
			{
				moveLeft();
				Console.WriteLine("button 1");
			}
			if (button2.touchSelect(touchCollection))
			{
				moveRight();
				Console.WriteLine("button 2");
			}
			else
			{
				moveDown();
			}

		}


	}
}
