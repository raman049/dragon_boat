using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace com.dragon_boat
{
	public class Bounce
	{
		Texture2D t2dBoat, whiteRectangle, t2dFinishLine, t2dFloat;
		Rectangle boatRect, finishLineRect, floatRect;
		Vector2 boatPostion;
		Button button1, button2;
		Animation animationRight, animationLeft, animationForward, currentAnimation, animationSteady, animationFloat;
		int width, height;
		SpriteFont font;
		Stopwatch stopWatch;
		string elapsedTime;

		public float X { get; set; }
		public float Y { get; set; }


		public Bounce(GraphicsDevice graphicsDevice)
		{
			height = graphicsDevice.Viewport.Height;
			width = graphicsDevice.Viewport.Width;
			boatPostion = new Vector2(graphicsDevice.Viewport.Width / 2,
									   graphicsDevice.Viewport.Height * 0.85f);
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
			if (t2dFloat == null)
			{
				using (var stream = TitleContainer.OpenStream("Content/floats.png"))
				{
					t2dFloat = Texture2D.FromStream(graphicsDevice, stream);
				}
			}
			animationFloat = new Animation();
			animationFloat.AddFrame(new Rectangle(0, 0, 100, 100), TimeSpan.FromSeconds(.25));
			animationFloat.AddFrame(new Rectangle(100, 0, 100, 100), TimeSpan.FromSeconds(.250));
			animationFloat.AddFrame(new Rectangle(200, 0, 100, 100), TimeSpan.FromSeconds(.250));
			animationFloat.AddFrame(new Rectangle(300, 0, 100, 100), TimeSpan.FromSeconds(.250));

			boatRect = new Rectangle((int)(boatPostion.X - t2dBoat.Width / 2),
		(int)(boatPostion.Y - t2dBoat.Height / 2), graphicsDevice.Viewport.Width / 10, graphicsDevice.Viewport.Height * 3 / 10);
			finishLineRect = new Rectangle(0, 20, graphicsDevice.Viewport.Width, (int)(graphicsDevice.Viewport.Height * 0.02));
			whiteRectangle = new Texture2D(graphicsDevice, 1, 1);
			whiteRectangle.SetData(new[] { Color.White });

			button1 = new Button(graphicsDevice, new Rectangle(0, 0, graphicsDevice.Viewport.Width / 2, graphicsDevice.Viewport.Height));
			button2 = new Button(graphicsDevice, new Rectangle(graphicsDevice.Viewport.Width / 2, 0, graphicsDevice.Viewport.Width / 2, graphicsDevice.Viewport.Height));
			stopWatch = new Stopwatch();
			getTime();
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
				stopWatch.Stop();
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

			spriteBatch.DrawString(font, elapsedTime, new Vector2(100, 100), Color.LightSalmon);
			var sourceRectangle = currentAnimation.CurrentRectangle;
			spriteBatch.Draw(t2dBoat, boatRect, sourceRectangle, Color.White);
			//spriteBatch.Draw(whiteRectangle, finishLineRect, Color.White);
			//spriteBatch.Draw(t2dFinishLine, new Rectangle(0,0,10,10),new Rectangle(0,0,100,100) , Color.White);
			drawFinishLine(spriteBatch);
			drawFloat(spriteBatch);
		}

		public void drawFinishLine(SpriteBatch spriteBatch)
		{
			for (int i = 0; i < width / 2; i++)
			{
				int size = (int)(height * 0.02);
				spriteBatch.Draw(t2dFinishLine, new Rectangle(size * i, finishLineRect.Y, size, size), new Rectangle(0, 0, 100, 100), Color.White);
			}

		}
		public void drawFloat(SpriteBatch spriteBatch)
		{
			for (int j = 0; j < 5; j++)
			{
				for (int i = 0; i < 5; i++)
				{
					var sourceRectangle = animationFloat.CurrentRectangle;
					int size = (int)(width * 0.02);
					floatRect = new Rectangle((int)(width * 0.35f + i * (width * 0.35f)), (int)(width * 0.3f + j * (width * 0.3f)), size, size);
					spriteBatch.Draw(t2dFloat, floatRect, sourceRectangle, Color.White);
				}
			}
		}

		public void moveRight()
		{
			//j = 20;
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
			//GIVE DIRECTION TO BOAT
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
				runTimer();

			}
			else if (boolean_bl == true && boolean_br == false)
			{
				stopWatch.Start();
				moveLeft();
				currentAnimation = animationLeft;
				runTimer();
			}
			else if (boolean_bl == false && boolean_br == true)
			{
				moveRight();
				currentAnimation = animationRight;
				Console.WriteLine("button 2");
				//boolean_br = false;
				runTimer();
			}
			else
			{
				currentAnimation = animationSteady;
				//Console.WriteLine("else 1");
			}


			boatRect.X = (int)boatPostion.X;
			boatRect.Y = (int)boatPostion.Y;
			currentAnimation.Update(gameTime);
			animationFloat.Update(gameTime);
			getTime();
		}


		public void getTime()
		{
			TimeSpan ts = stopWatch.Elapsed;
			elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
		   ts.Hours, ts.Minutes, ts.Seconds,
		   ts.Milliseconds / 10);
			//Console.WriteLine("RunTime " + elapsedTime);
		}

		public void runTimer()
		{
			int timeout = 1000;
			int interval = Timeout.Infinite;
			TimerCallback callback = new TimerCallback(RunEvent);
			Timer timer = new Timer(callback, null, timeout, interval);
			timer.Change(0, 1000);
		}
		public void RunEvent(object state)
		{
			boolean_br = false;
			boolean_bl = false;
		}


	}

}
