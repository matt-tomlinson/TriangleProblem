using System;

namespace TriangleProblem {
	class Program {
		public static LineCollection LineCollection { get; set; }
		public static TriangleCollection TriangleCollection { get; set; }

		static void Main(string[] args) {
			ReadInData();
			ProcessData();
		}

		private static void ProcessData() {
			TriangleCollection = new TriangleCollection();
			FindSubSegments();
		}

		private static void FindSubSegments() {
			for (int i = 0; i < LineCollection.Length; i++) {
				LineSegment line1 = LineCollection.Lines[i];
				for (int j = i + 1; j < LineCollection.Length; j++) {
					LineSegment line2 = LineCollection.Lines[j];
					line1.Intersects(line2);
				}
			}
		}

		private static void ReadInData() {
			string text = System.IO.File.ReadAllText(@"D:\repos\TriangleProblem\TriangleProblem\data\triangles1.txt");
			ParseTextToData(text);
		}

		private static void ParseTextToData(string text) {
			LineCollection = new LineCollection();

			var lines = text.Split("\n");
			try {
				foreach (var line in lines) {
					string lineStr = "";

					if (line.Contains("\r")) {
						lineStr = line.Substring(0, line.Length - 1);
					} else {
						lineStr = line;
					}

					string[] points = lineStr.Split(" ");
					var points1 = points[0].Split(",");
					var points2 = points[1].Split(",");

					Point p1 = new Point(int.Parse(points1[0]), int.Parse(points1[1]));
					Point p2 = new Point(int.Parse(points2[0]), int.Parse(points2[1]));

					LineSegment newLineSegment = new LineSegment(p1, p2);
					LineCollection.Lines.Add(newLineSegment);
				}
			} catch (Exception ex) {
				Console.WriteLine(ex);
			}

			Console.WriteLine("Loaded Data.");
		}
	}
}
