using System;
using System.Collections.Generic;
using System.Text;

namespace TriangleProblem {
	public class LineSegment {
		public Point Point1 { get; set; }
		public Point Point2 { get; set; }
		public float Slope { get; set; }
		public float YIntercept { get; set; }
		public List<LineSegment> SubSegments { get; set; }

		public LineSegment(Point p1, Point p2) {
			Point1 = p1;
			Point2 = p2;

			float rise = Point2.Y - Point1.Y;
			float run = Point2.X - Point1.X;

			Slope = (float)rise / run;
			YIntercept = Point1.Y - (Slope * Point1.X);
		}

		public bool Intersects(LineSegment line) {
			if (!Equals(line)) {
				float A1 = Point2.Y - Point1.Y;
				float B1 = Point1.X - Point2.X;
				float C1 = (A1 * Point1.X) + (B1 * Point1.Y);

				float A2 = line.Point2.Y - line.Point1.Y;
				float B2 = line.Point1.X - line.Point2.X;
				float C2 = (A2 * line.Point1.X) + (B2 * line.Point1.Y);

				float det = (A1 * B2) - (A2 * B1);

				if (det == 0) {
					//Console.WriteLine($"Line1: {this.ToString()} and Line2: {line.ToString()} are parallel.");
				} else {
					float x = ((B2 * C1) - (B1 * C2)) / det;
					float y = ((A1 * C2) - (A2 * C1)) / det;

					if (x <= Math.Max(Point1.X, Point2.X) && x >= Math.Min(Point1.X, Point2.X) &&
						y <= Math.Max(Point1.Y, Point2.Y) && y >= Math.Min(Point1.Y, Point2.Y)) {
						Point intersectPoint = new Point(x, y);
						if (intersectPoint.Equals(Point1) || intersectPoint.Equals(Point2)) {
							//Console.WriteLine($"intersect point is at the end of the line segment {intersectPoint.ToString()}");
						} else {
							Console.WriteLine($"intersect point is in the line segment {intersectPoint.ToString()}");
							//TODO add subsegments
						}
					}
				}
			}
			return false;
		}

		public bool Equals(LineSegment line) {
			if (Point1.Equals(line.Point1)) {
				if (Point2.Equals(line.Point2)) {
					return true;
				}
			} else if (Point1.Equals(line.Point2)) {
				if (Point2.Equals(line.Point1)) {
					return true;
				}
			}
			return false;
		}

		public override string ToString() {
			string line = Point1.ToString() + "-" + Point2.ToString();
			return line;
		}
	}
}
