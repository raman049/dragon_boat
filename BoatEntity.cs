using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace com.dragon_boat
{
	public class BoatEntity
	{

		static Texture2D boatForward;
		BoatRectangle boatRectangle;
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
		public GraphicsDevice GraphicsDevice { get; private set; }


		public BoatEntity(GraphicsDevice graphicsDevice)
		{
			boatRectangle = new BoatRectangle();
			if (boatForward == null)
			{
				using (var stream = TitleContainer.OpenStream("Content/boatForward.png"))
				{
					boatForward = Texture2D.FromStream(graphicsDevice, stream);



				}
			}
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			//	Vector2 topLeftOfSprite = new Vector2(boatRectangle.X, boatRectangle.Y);
			Color tintColor = Color.White;
			Rectangle boatRectangle1 = boatRectangle.Boat1Rectangle();
			spriteBatch.Draw(boatForward, boatRectangle1, tintColor);

		}


	}
}
