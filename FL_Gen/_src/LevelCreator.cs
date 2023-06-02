using System;
using System.Collections.Generic;

public class LevelCreator {
    public Level Create(int flasksCount, int ballsCountInFlask) {
        var types = new List<BallType>((BallType[])Enum.GetValues(typeof(BallType)));

        var flasks = new List<List<BallType>>();
        for (var i = 0; i < flasksCount; i++) {
            flasks.Add(new List<BallType>());
        }

        var allBalls = new List<BallType>();
        
        for (var i = 0; i < flasksCount; i++) {
            for (var j = 0; j < ballsCountInFlask; j++) {
                allBalls.Add(types[i]);
            }
        }
        allBalls.Shuffle();


        var ballIndex = 0;
        foreach (var flask in flasks) {
            for (var i = 0; i < ballsCountInFlask; i++) {
                flask.Add(allBalls[ballIndex]);
                ballIndex++;
            }
        }

        var level = new Level {
            ballCount = ballsCountInFlask,
            flasks = flasks
        };
        
        return level;
    }
}