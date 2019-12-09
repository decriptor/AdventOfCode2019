using System;
using System.Collections.Generic;
using System.IO;

namespace Day1
{
	class Program
	{
		static readonly Dictionary<long, long> knownFuel = new Dictionary<long, long> ();

		static readonly List<int> masses = new List<int> {
			74392, 127667, 69569, 148530, 83690, 84002, 122964, 107123, 110494, 144519,
			63331, 61941, 93209, 93122, 88787, 67333, 94900, 134472, 94647, 104628, 56171,
			147712, 78930, 58819, 103374, 114589, 84131, 52655, 63193, 94710, 75332, 75719,
			147913, 100682, 105546, 73930, 102283, 53809, 145886, 133502, 97903, 140937, 104102,
			89440, 137660, 110714, 134163, 63116, 86505, 135191, 60768, 126201, 79596, 64299,
			135513, 53340, 110859, 136534, 80519, 56380, 68566, 101326, 105695, 146000, 136744,
			105429, 147815, 88211, 106856, 97483, 133855, 73925, 60995, 88195, 123525, 98639, 71255,
			146726, 112901, 119930, 68304, 121502, 54137, 75097, 131582, 102247, 57260, 66597,
			142929, 122416, 126247, 64350, 81531, 71867, 50494, 101267, 60412, 109593, 127215, 110059
		};

		static int knownFuelHits = 0;

		static void Main ()
		{
			Console.WriteLine ("Advent of Code 2019 - Day 1");
			Console.WriteLine ("Examples Part 1:");
			Console.WriteLine ($"\tFuel for 12: {CalculateFuel (12)}");
			Console.WriteLine ($"\tFuel for 14: {CalculateFuel (14)}");
			Console.WriteLine ($"\tFuel for 1969: {CalculateFuel (1969)}");
			Console.WriteLine ($"\tFuel for 100756: {CalculateFuel (100756)}");

			Console.WriteLine ("Examples Part 2:");
			Console.WriteLine ($"\tFuel for 12: {CalculateFuelPart2 (12)}");
			Console.WriteLine ($"\tFuel for 14: {CalculateFuelPart2 (14)}");
			Console.WriteLine ($"\tFuel for 1969: {CalculateFuelPart2 (1969)}");
			Console.WriteLine ($"\tFuel for 100756: {CalculateFuelPart2 (100756)}");


			Console.WriteLine ($"\n\nPart 1");
			long total = 0;
			foreach (var mass in masses)
				total += CalculateFuel (mass);

			Console.WriteLine ($"Sum of fuel requirements: {total}");
			Console.WriteLine ($"Part1 Stats: DictionaryHitCount {knownFuelHits}");

			Console.WriteLine ($"\n\nPart 2");
			total = 0;
			foreach (var mass in masses)
				total += CalculateFuelPart2 (mass);

			Console.WriteLine ($"Sum of fuel requirements: {total}");
			Console.WriteLine ($"Part2 Stats: DictionaryHitCount {knownFuelHits}");
		}

		static long CalculateFuel (long mass)
		{
			if (knownFuel.ContainsKey (mass)) {
				knownFuelHits++;
				return knownFuel[mass];
			}

			var fuel = (mass / 3) - 2;
			knownFuel.Add (mass, fuel);
			return fuel;
		}

		static long CalculateFuelPart2 (long mass, long total = 0)
		{
			if (mass <= 0)
				return total;

			long newMass = CalculateFuel (mass);
			if (newMass >= 0)
				total += newMass;

			return CalculateFuelPart2 (newMass, total);
		}
	}
}
