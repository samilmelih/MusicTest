using System;
using System.Collections.Generic;

public class Composer
{
	int melodyCount;
	int currMelody;

	List<int>[] graph;

	public Composer(int melodyCount)
	{
		Random rnd = new Random();

		this.melodyCount = melodyCount;
		this.currMelody = rnd.Next(0, melodyCount);

		graph = new List<int>[melodyCount];
	}

	public void AddMelody(string melodyStr)
	{
		int[] melody = ParseMelody(melodyStr);

		graph[melody[0]] = new List<int>(melody.Length);
		for(int i = 0; i < melody.Length; i++)
		{
			if(i != 0)
				graph[melody[0]].Add(melody[i]);
		}
	}

	public int NextMelody()
	{
		Random rnd = new Random();

		int possibleMelodyCount = graph[currMelody].Count;
		int nextMelodyIndex = rnd.Next(0, possibleMelodyCount);
		currMelody = graph[currMelody][nextMelodyIndex];

		return currMelody;
	}

	static int[] ParseMelody(string melody)
	{
		return Array.ConvertAll(melody.Split('-'), int.Parse);
	}
}
