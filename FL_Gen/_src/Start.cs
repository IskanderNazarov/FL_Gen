using System;

internal class Start {
    private int levelNumber = 1;

    public static void Main(string[] args) {
        new Start().StartGenerating();
    }

    private ComplexityData compl_1; //5 levels are assembled manually 

    private const int TOTAL_COUNT = 5000;

    private ComplexityData[] complexities = {
        //new(complexity: 1, levelsCount: 7, colorsCount: 5, sameColorProb1: 1, sameColorProb2: 100),//manually
        new ComplexityData(compl: 2, maxLvlNum: 15, idCount: 6, sameIDProb1: 70, sameIDProb2: 30, freq5_1: 5,
            freq5_2: 2), //start with level 10, up tp 17
        new ComplexityData(compl: 3, maxLvlNum: 30, idCount: 7, sameIDProb1: 60, sameIDProb2: 30, freq5_1: 5,
            freq5_2: 2),
        new ComplexityData(compl: 4, maxLvlNum: 50, idCount: 8, sameIDProb1: 50, sameIDProb2: 20, freq5_1: 5,
            freq5_2: 2),
        new ComplexityData(compl: 5, maxLvlNum: 90, idCount: 9, sameIDProb1: 40, sameIDProb2: 10, freq5_1: 5,
            freq5_2: 2),
        new ComplexityData(compl: 6, maxLvlNum: 150, idCount: 10, sameIDProb1: 30, sameIDProb2: 5, freq5_1: 4,
            freq5_2: 2),
        new ComplexityData(compl: 7, maxLvlNum: 300, idCount: 11, sameIDProb1: 20, sameIDProb2: 5, freq5_1: 5,
            freq5_2: 2),
        new ComplexityData(compl: 8, maxLvlNum: TOTAL_COUNT, idCount: 12, sameIDProb1: 8, sameIDProb2: 4, freq5_1: 3,
            freq5_2: 2),
    };
    /*private ComplexityData[] complexities = {
        //new(complexity: 1, levelsCount: 7, colorsCount: 5, sameColorProb1: 1, sameColorProb2: 100),//manually
        new(compl: 2, maxLvlNum: 5, idCount: 6, sameIDProb1: 80, sameIDProb2: 30, freq5_1: 5,freq5_2: 2), //start with level 10, up tp 17
        new(compl: 3, maxLvlNum: 10, idCount: 10, sameIDProb1: 60, sameIDProb2: 30, freq5_1: 5, freq5_2: 2),
    };*/

    private void StartGenerating() {
        const float a = 4.6f;
        const float b = 0.47f;
        const float c = 5;
        //const float ttt = a * Math.Log(1 * b) + c;
        //var flasksCount = a * Math.Log(lvlNum * b) + c;
        //1 -> 9 levels will be generated manually

        var levelCounter = 11;

        foreach (var cd in complexities) {
            var levelsCountForComplexity = cd.MaxLvlNumber - levelCounter + 1;
            //generate levels for each complexity data
            for (var i = 0; i < levelsCountForComplexity; i++) {
                var probOfTheSameID =
                    (int) Utils.Lerp(cd.SameIdProb1, cd.SameIdProb2, (float) i / (cd.MaxLvlNumber - 1));
                var freqOf_5_BallsFlask =
                    (int) Utils.Lerp(cd.freqOf5Flask1, cd.freqOf5Flask2, (float) i / (cd.MaxLvlNumber - 1));
                /*Console.WriteLine($"Probability for level {levelCounter} is {probOfTheSameID}");
                Console.WriteLine($"freqOf_5_BallsFlask is {freqOf_5_BallsFlask}");*/
                var ballsCount = (i + 1) % freqOf_5_BallsFlask == 0 ? 5 : 4;
                //exclude  levels with completed flasks
                Level level;
                do {
                    level = new LevelCreatorDefault().Create(cd.IdCount, ballsCount, probOfTheSameID);
                } while (level.HasSolvedFlask());

                if (level.HasSolvedFlask()) {
                    Console.WriteLine("Level number: " + levelCounter);
                }
                //var level = new LevelCreatorShuffling().Create(cd.IdCount + 2, ballsCount, probOfTheSameID);

                Utils.WriteLevelToFile(level.ToString(), levelCounter);
                levelCounter++;
            }
        }
    }
}