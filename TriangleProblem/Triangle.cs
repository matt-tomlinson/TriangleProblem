using System;
using System.Collections.Generic;
using System.Text;

namespace TriangleProblem {
	public class Triangle {
		public List<LineSegment> Sides { get; set; }

		public Triangle(LineSegment Side1, LineSegment Side2, LineSegment Side3) {
			Sides = new List<LineSegment>() { Side1, Side2, Side3 };
		}

		public bool Equals(Triangle triangle) {
			foreach (var side in Sides) {
				if (!triangle.ContainsSide(side)) {
					return false;
				}
			}

			return true;
		}

		public bool ContainsSide(LineSegment side) {
			foreach (var savedSide in Sides) {
				if (side.Equals(savedSide)) {
					return true;
				}
			}
			return false;
		}

		public override string ToString() {
			string triangle = "triangle:\n";
			foreach (var line in Sides) {
				triangle += " " + line.ToString() + "\n";
			}
			return triangle;
		}
	}
}
