using System;
using System.Collections.Generic;
using System.Text;

namespace TriangleProblem {
	public class Point {
		public float X { get; set; }
		public float Y { get; set; }

		public Point(float x, float y) {
			X = x;
			Y = y;
		}

		public bool Equals(Point point) {
			if (X == point.X && Y == point.Y) { return true; }
			return false;
		}

		public override string ToString() {
			string point = "(" + X.ToString() + ", " + Y.ToString() + ")";
			return point;
		}
	}
}
