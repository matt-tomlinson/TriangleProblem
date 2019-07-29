using System;
using System.Collections.Generic;
using System.Text;

namespace TriangleProblem {
	public class TriangleCollection {
		public List<Triangle> Triangles { get; set; }

		public TriangleCollection() {
			Triangles = new List<Triangle>();
		}

		public override string ToString() {
			string triangleCollection = "";

			foreach (var triangle in Triangles) {
				triangleCollection += triangle.ToString() + "\n";
			}

			return triangleCollection;
		}

		internal bool ContainsTriangle(Triangle triangle) {
			foreach (var savedTriangle in Triangles) {
				if (savedTriangle.Equals(triangle)) {
					return true;
				}
			}
			return false;
		}
	}
}
