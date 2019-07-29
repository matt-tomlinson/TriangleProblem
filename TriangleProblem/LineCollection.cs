using System;
using System.Collections.Generic;
using System.Text;

namespace TriangleProblem {
	public class LineCollection {
		public List<LineSegment> Lines { get; set; }
		public int Length { get => Lines.Count; }

		public LineCollection() {
			Lines = new List<LineSegment>();
		}

		public bool ContainsLine(LineSegment line) {
			foreach (LineSegment lineSegment in Lines) {
				if (lineSegment.Equals(line)) {
					return true;
				}
			}
			return false;
		}

		public void AddLine(LineSegment line) {
			Lines.Add(line);
		}

		public void RemoveLine(int index) {
			Lines.RemoveAt(index);
		}

		public void RemoveLine(LineSegment line) {
			Lines.Remove(line); // does this work?
		}

		public override string ToString() {
			string lineCollection = "";

			foreach (var line in Lines) {
				lineCollection += line.ToString() + "\n";
			}

			return lineCollection;
		}
	}
}
