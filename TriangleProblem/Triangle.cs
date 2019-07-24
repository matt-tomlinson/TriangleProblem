using System;
using System.Collections.Generic;
using System.Text;

namespace TriangleProblem {
	public class Triangle {
		public LineSegment[] Sides { get; set; }

		public Triangle() {
			Sides = new LineSegment[3];
		}
	}
}
