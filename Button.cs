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

	public Button(GraphicsDevice graphicsDevice, Rectangle bRect)
		{
			buttonRectangle = bRect;
			SimpleTexture  = new Texture2D(graphicsDevice, 1, 1);
			SimpleTexture.SetData(new[] { Color.White });
		}
public bool touchSelect(TouchCollection touchCollection)
		{
			Rectangle target = buttonRectangle;
			//touchCollection = TouchPanel.GetState();
			foreach (TouchLocation tl in touchCollection)
			{
				if (tl.State == TouchLocationState.Pressed && tl.Position.X < target.Right && tl.Position.X > target.Left &&
					tl.Position.Y < target.Bottom && tl.Position.Y > target.Top)
				{
					return true;
				}
			} 
			return false;

		}
		public void Draw(SpriteBatch spriteBatch)
		{
			Color tintColor = Color.White;
			spriteBatch.Draw(SimpleTexture, buttonRectangle, tintColor);
		}
	}
}