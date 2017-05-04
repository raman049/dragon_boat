using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace com.dragon_boat
{
	public class BoatRectangle
	{
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
		public BoatRectangle()
		{
		}
		public Rectangle Boat1Rectangle()
		{
			return new Rectangle(89, 80, 175, 500);
		}

	}
}
