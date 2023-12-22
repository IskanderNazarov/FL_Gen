using System;
using System.Collections.Generic;

internal class Start {
    private int levelNumber = 1;

    public static void Main(string[] args) {
        new Start().StartGenerating();
    }

    private ComplexityData compl_1; //5 levels are assembled manually 

    private const int TOTAL_COUNT = 2000;
    private ComplexityData[] complexities = {
        //new(complexity: 1, levelsCount: 7, colorsCount: 5, sameColorProb1: 1, sameColorProb2: 100),//manually
        new(complexity: 2, maxLevelNumber: 15, colorsCount: 6, sameColorProb1: 80, sameColorProb2: 30),//start with level 10, up tp 17
        new(complexity: 3, maxLevelNumber: 30, colorsCount: 7, sameColorProb1: 60, sameColorProb2: 30),
        new(complexity: 4, maxLevelNumber: 50, colorsCount: 8, sameColorProb1: 50, sameColorProb2: 20),
        new(complexity: 5, maxLevelNumber: 90, colorsCount: 9, sameColorProb1: 40, sameColorProb2: 10),
        new(complexity: 6, maxLevelNumber: 150, colorsCount: 10, sameColorProb1: 30, sameColorProb2: 5),
        new(complexity: 7, maxLevelNumber: 300, colorsCount: 11, sameColorProb1: 20, sameColorProb2: 5),
        new(complexity: 8, maxLevelNumber: TOTAL_COUNT, colorsCount: 12, sameColorProb1: 8, sameColorProb2: 4),
    };

    private void StartGenerating() {
        const float a = 4.6f;
        const float b = 0.47f;
        const float c = 5;
        //const float ttt = a * Math.Log(1 * b) + c;
        //var flasksCount = a * Math.Log(lvlNum * b) + c;
        //1 -> 9 levels will be generated manually

        var levelCounter = 11;
        foreach (var cd in complexities) {
            var levelsCountForComplexity = cd.MaxLevelNumber - levelCounter + 1;
            //generate levels for each complexity data
            for (var i = 0; i < levelsCountForComplexity; i++) {
                var probability = (int) Utils.Lerp(cd.sameColorProb_1, cd.sameColorProb_2, (float) i / (cd.MaxLevelNumber - 1));
                Console.WriteLine($"Probability for level {levelCounter} is {probability}");
                //var level = new LevelCreator().Create(cd.colorsCount, 4, probability);
                var level = new LevelCreatorShuffling().Create(cd.colorsCount + 2, 4, probability);

                Utils.WriteLevelToFile(level.ToString(), levelCounter);
                levelCounter++;
            }
        }
    }
}