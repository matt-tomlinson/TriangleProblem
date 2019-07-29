using System;
using System.IO;
using System.Reflection;

namespace TriangleProblem {
	class Program {
		public static LineCollection LineSegmentCollection { get; set; }
		public static LineCollection AllLinesCollection { get; set; }
		public static TriangleCollection TriangleCollection { get; set; }

		static void Main(string[] args) {
			ReadInData();
			ProcessData();
			DisplayData();
			Wait();
		}

		private static void Wait() {
			var finished = false;

			while (!finished) {
				var key = Console.ReadKey();
				if (key.KeyChar.Equals('q')) {
					finished = true;
				}
			}

			Environment.Exit(-1);
		}

		private static void ProcessData() {
			FindSubSegments();
			PopulateAllLinesCollection();
			FindTriangles();
		}

		private static void DisplayData() {
			var count = 1;

			foreach (var triangle in TriangleCollection.Triangles) {
				Console.WriteLine($"{count} {triangle.ToString()}");
				count += 1;
			}
			Console.WriteLine($"Counted {TriangleCollection.Triangles.Count} Triangles.");
		}

		private static void PopulateAllLinesCollection() {
			AllLinesCollection = new LineCollection();
			foreach (var lineSegment in LineSegmentCollection.Lines) {
				if (!AllLinesCollection.ContainsLine(lineSegment)) {
					AllLinesCollection.AddLine(lineSegment);

				}
				foreach (var subSegment in lineSegment.SubSegments) {
					if (!AllLinesCollection.ContainsLine(subSegment)) {
						AllLinesCollection.AddLine(subSegment);
					}
				}
			}
		}

		private static void FindTriangles() {
			TriangleCollection = new TriangleCollection();

			foreach (var line1 in AllLinesCollection.Lines) {
				foreach (var line2 in AllLinesCollection.Lines) {
					if (!line1.Equals(line2)) {
						foreach (var line3 in AllLinesCollection.Lines) {
							if (!line1.Equals(line3) && !line2.Equals(line3)) {
								if (AreTriangleSides(line1, line2, line3)) {
									var triangle = new Triangle(line1, line2, line3);
									if (!TriangleCollection.ContainsTriangle(triangle)) {
										TriangleCollection.Triangles.Add(triangle);
									}
								}
							}
						}
					}
				}
			}
		}

		private static bool AreTriangleSides(LineSegment line1, LineSegment line2, LineSegment line3) {
			if (line1.SharesEndPoint(line2, out Point sharedPoint12)) {
				if (line1.SharesEndPoint(line3, out Point sharedPoint13)) {
					if (line2.SharesEndPoint(line3, out Point sharedPoint23)) {
						if (!sharedPoint12.Equals(sharedPoint13) && !sharedPoint13.Equals(sharedPoint23) && !sharedPoint23.Equals(sharedPoint12)) {
							if (line1.Slope != line2.Slope && line2.Slope != line3.Slope && line3.Slope != line1.Slope) {
								return true;
							}
						}
					}
				}
			}

			return false;
		}

		private static void FindSubSegments() {
			for (int i = 0; i < LineSegmentCollection.Length; i++) {
				LineSegment line1 = LineSegmentCollection.Lines[i];
				for (int j = i + 1; j < LineSegmentCollection.Length; j++) {
					LineSegment line2 = LineSegmentCollection.Lines[j];
					line1.Intersects(line2);
				}
			}
		}

		private static void ReadInData() {
			try {
				string file = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\triangles1.txt");
				string text = File.ReadAllText(file);
				ParseTextToData(text);
			} catch (Exception ex) {
				Console.WriteLine($"Failed to read in Data: {ex}");
			}
		}

		private static void ParseTextToData(string text) {
			LineSegmentCollection = new LineCollection();

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
					LineSegmentCollection.Lines.Add(newLineSegment);
				}
			} catch (Exception ex) {
				Console.WriteLine(ex);
			}

			Console.WriteLine("Loaded Data.");
		}
	}
}
