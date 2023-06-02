using System;

internal class Start {
    public static void Main(string[] args) {
        new Start().StartGenerating();
    }

    private void StartGenerating() {
        var level = new LevelCreator().Create(5, 4);
        Console.WriteLine(level);
    }
}