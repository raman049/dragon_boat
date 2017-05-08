using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace com.dragon_boat
{
	public class Bounce
	{
		Texture2D t2dBoat, whiteRectangle, t2dFinishLine;
		Rectangle bllBounds, boatRect, finishLineRect;
		Vector2 ballPosition, boatPostion;
		Button button1, button2;
		Animation animationRight, animationLeft, animationForward, currentAnimation, animationSteady;
		int width, height;
		SpriteFont font;

		public float X { get; set; }
		public float Y { get; set; }


		public Bounce(GraphicsDevice graphicsDevice)
		{
			height = graphicsDevice.Viewport.Height;
			width = graphicsDevice.Viewport.Width;
			boatPostion = new Vector2(graphicsDevice.Viewport.Width / 2,
									   graphicsDevice.Viewport.Height * 0.85f);
			//ballVelocity = new Vector2(4, 10);
			if (t2dBoat == null)
			{
				using (var stream = TitleContainer.OpenStream("Content/boat.png"))
				{
					t2dBoat = Texture2D.FromStream(graphicsDevice, stream);

				}
			}
			animationSteady = new Animation();
			animationSteady.AddFrame(new Rectangle(0, 0, 175, 510), TimeSpan.FromSeconds(.25));
			animationSteady.AddFrame(new Rectangle(5, 5, 175, 510), TimeSpan.FromSeconds(.250));
			animationRight = new Animation();
			animationRight.AddFrame(new Rectangle(0, 0, 175, 510), TimeSpan.FromSeconds(.25));
			animationRight.AddFrame(new Rectangle(175 * 2, 0, 175, 510), TimeSpan.FromSeconds(.25));
			animationLeft = new Animation();
			animationLeft.AddFrame(new Rectangle(0, 0, 175, 510), TimeSpan.FromSeconds(.25));
			animationLeft.AddFrame(new Rectangle(175, 0, 175, 510), TimeSpan.FromSeconds(.25));
			animationForward = new Animation();
			animationForward.AddFrame(new Rectangle(0, 0, 175, 510), TimeSpan.FromSeconds(.25));
			animationForward.AddFrame(new Rectangle(175 * 3, 0, 175, 510), TimeSpan.FromSeconds(.25));

			if (t2dFinishLine == null)
			{
				using (var stream = TitleContainer.OpenStream("Content/checkers.png"))
				{
					t2dFinishLine = Texture2D.FromStream(graphicsDevice, stream);
				}
			}
					boatRect = new Rectangle((int)(boatPostion.X - t2dBoat.Width / 2),
				(int)(boatPostion.Y - t2dBoat.Height / 2), graphicsDevice.Viewport.Width / 10, graphicsDevice.Viewport.Height * 3 / 10);
				finishLineRect = new Rectangle(0,20, graphicsDevice.Viewport.Width, (int)(graphicsDevice.Viewport.Height*0.02));
		
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
			if (!graphicsDevice.Viewport.Bounds.Contains(boatRect))
			{
				boatPostion.X = graphicsDevice.Viewport.Width / 2;
				boatPostion.Y = graphicsDevice.Viewport.Height * 0.7f;
				//ballVelocity = -ballVelocity;
				//ballPosition += ballVelocity;
			}

			else
			{
				//move the ball a bit
				//ballPosition += ballVelocity;

			}


		}

		public void Draw(SpriteBatch spriteBatch)
		{
			Color tintColor = Color.White;
			Color backgroundColor = new Color(113, 247, 236);
			spriteBatch.GraphicsDevice.Clear(backgroundColor);
			//spriteBatch.Draw(whiteRectangle, ballBounds, tintColor);
			//spriteBatch.Draw(whiteRectangle, boatRect, tintColor);
			//	spriteBatch.Draw(t2dBoat, boatRect, tintColor);
			//	spriteBatch.DrawString( font, "text to print", boatPostion, Color.Red);
			//spriteBatch.Draw(ballTexture, ballBounds, tintColor);
			//button1.Draw(spriteBatch);
			//button2.Draw(spriteBatch);
			spriteBatch.DrawString(font, "text to 23423423423423423 print", new Vector2(40, 40), Color.Red);
			var sourceRectangle = currentAnimation.CurrentRectangle;
			spriteBatch.Draw(t2dBoat, boatRect, sourceRectangle, Color.White);
			//spriteBatch.Draw(whiteRectangle, finishLineRect, Color.White);
			//spriteBatch.Draw(t2dFinishLine, new Rectangle(0,0,10,10),new Rectangle(0,0,100,100) , Color.White);
			drawFinishLine(spriteBatch);
		}

		public void drawFinishLine(SpriteBatch spriteBatch)
		{ for (int i = 0; i < width/2; i++)
			{
				int size = (int)(height * 0.02);
				spriteBatch.Draw(t2dFinishLine, new Rectangle(size*i,finishLineRect.Y,size,size),new Rectangle(0,0,100,100) , Color.White);
			}
		
		}

		public void moveRight()
		{
			boatPostion.X += 10;
			boatPostion.Y -= 20;
		}
		public void moveLeft()
		{
			boatPostion.X -= 10;
			boatPostion.Y -= 20;
		}
		public void moveForward()
		{
			//boatPostion.X -= 10;
			boatPostion.Y -= 25;
		}
		public void moveDown()
		{
			boatPostion.Y -= (int)0.2;
		}

		TouchCollection touchCollection;
		Boolean boolean_br, boolean_bl;
		public void updateButton(GameTime gameTime)
		{
			touchCollection = TouchPanel.GetState();
			//currentAnimation = animationSteady;
			//if ((button1.touchSelect(touchCollection)) && (button2.touchSelect(touchCollection)))
			//{
			//	moveForward();
			//	currentAnimation = animationForward;
			//	Console.WriteLine("button 1 && button 2");
			//}
			//else 
			if (button1.touchSelect(touchCollection))
			{
				boolean_bl = true;
				if (button2.touchSelect(touchCollection))
				{
					boolean_br = true;
				}
			}
			if (button2.touchSelect(touchCollection))
			{
				boolean_br = true;
				if (button1.touchSelect(touchCollection))
				{
					boolean_bl = true;
				}
			}

			if (boolean_bl == true && boolean_br == true)
			{
				moveForward();
				currentAnimation = animationForward;
				Console.WriteLine("button 1 && button 2");
				boolean_br = false;
				boolean_bl = false;
			}
			else
			{
				if (boolean_bl == true)
				{
					moveLeft();
					currentAnimation = animationLeft;
					Console.WriteLine("button 1");
					boolean_bl = false;
				}
				if (boolean_br == true)
				{
					moveRight();
					currentAnimation = animationRight;
					Console.WriteLine("button 2");
					boolean_br = false;
				}
				else
				{
					currentAnimation = animationSteady;
				}
			}

			boatRect.X = (int)boatPostion.X;
			boatRect.Y = (int)boatPostion.Y;
			currentAnimation.Update(gameTime);
		}

	}

}
