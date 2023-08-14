using System;

internal class Start {
    public static void Main(string[] args) {
        new Start().StartGenerating();
    }

    private ComplexityData compl_1;//5 levels assembling manually 
    private ComplexityData compl_2 = new(10, 2, 6); 

    private void StartGenerating() {
        var level = new LevelCreator().Create(compl_2);
        Console.WriteLine(level);
    }
}