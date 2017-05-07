using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
namespace com.dragon_boat

{
	public class Button
	{
		Rectangle buttonRectangle;
		Texture2D SimpleTexture;
		Boolean output;

		public Button(GraphicsDevice graphicsDevice, Rectangle bRect)
		{
			buttonRectangle = bRect;
			SimpleTexture = new Texture2D(graphicsDevice, 1, 1);
			SimpleTexture.SetData(new[] { Color.White });
		}

		public bool touchSelect(TouchCollection touchCollection)
		{
			Rectangle target = buttonRectangle;
			foreach (TouchLocation tl in touchCollection)
			{
				if (tl.State == TouchLocationState.Pressed && tl.Position.X < target.Right && tl.Position.X > target.Left &&
					tl.Position.Y < target.Bottom && tl.Position.Y > target.Top)
				{
					output = true;
				}
				//else if (tl.State == TouchLocationState.Released)
				//{
				//	output = false;
				//}
				else
				{
					output = false;
				}
			}
			return output;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			Color tintColor = Color.White;
			spriteBatch.Draw(SimpleTexture, buttonRectangle, tintColor);
		}

		public void DrawT2dButton(SpriteBatch spriteBatch, Texture2D t2d)
		{
			Color tintColor = Color.White;
			spriteBatch.Draw(t2d, buttonRectangle, tintColor);
		}

		}
	}
