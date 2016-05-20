using System;
using UIKit;

namespace CustomDraw.iOS
{
	public class VESLine
	{
		public UIBezierPath Path {
			get;
			set;
		}

		public UIColor Color {
			get;
			set;
		}

		public byte Index {
			get;
			set;
		}
	}
}