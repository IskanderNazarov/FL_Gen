using System;

internal class Start {
    public static void Main(string[] args) {
        new Start().StartGenerating();
    }

    private ComplexityData compl_1; //5 levels are assembled manually 

    private ComplexityData[] complexities = {
        new(complexity: 2, levelsCount: 5, colorsCount: 4, sameColorProb1: 100, sameColorProb2: 100),
        /*new(complexity: 3, levelsCount: 3, colorsCount: 5, sameColorProb1: 5, sameColorProb2: 90),
        new(complexity: 4, levelsCount: 3, colorsCount: 6, sameColorProb1: 5, sameColorProb2: 90),
        new(complexity: 5, levelsCount: 3, colorsCount: 7, sameColorProb1: 5, sameColorProb2: 90),
        new(complexity: 6, levelsCount: 3, colorsCount: 8, sameColorProb1: 5, sameColorProb2: 90),
        new(complexity: 7, levelsCount: 3, colorsCount: 9, sameColorProb1: 5, sameColorProb2: 90),
        new(complexity: 8, levelsCount: 3, colorsCount: 10, sameColorProb1: 5, sameColorProb2: 90),
        new(complexity: 9, levelsCount: 3, colorsCount: 11, sameColorProb1: 5, sameColorProb2: 90),*/
    };

    private void StartGenerating() {
        var levelCounter = 1;
        foreach (var cd in complexities) {
            //generate levels for each complexity data
            for (var i = 0; i < cd.levelsCount; i++) {
                var probability = (int) Utils.Lerp(cd.sameColorProb_1, cd.sameColorProb_2, (float) i / (cd.levelsCount - 1));
                Console.WriteLine($"Probability for level {levelCounter} is {probability}");
                var level = new LevelCreator().Create(cd.colorsCount, 4, probability);

                Utils.WriteLevelToFile(level.ToString(), levelCounter);
                levelCounter++;
            }
        }
    }
}