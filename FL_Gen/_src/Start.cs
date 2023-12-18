using System;

internal class Start {

    private ComplexityData[] complexityData = {
        new ComplexityData {complexity = 1, levelsCount = 3, flasksCount = 3},
        new ComplexityData {complexity = 2, levelsCount = 3, flasksCount = 4},
        new ComplexityData {complexity = 3, levelsCount = 2, flasksCount = 5},
        new ComplexityData {complexity = 4, levelsCount = 2, flasksCount = 5},
        new ComplexityData {complexity = 5, levelsCount = 2, flasksCount = 8},
        new ComplexityData {complexity = 6, levelsCount = 2, flasksCount = 11},
    };

    private int levelNumber = 1;
    public static void Main(string[] args) {
        new Start().StartGenerating();
    }

    private void StartGenerating() {
        foreach (var data in complexityData) {
            for (var i = 0; i < data.levelsCount; i++) {
                var level = new LevelCreator().Create(data.flasksCount, 4);
                Utils.WriteLevelToFile(level.ToString(), levelNumber, data.complexity);

                levelNumber++;
            }
        }
        
    }
}