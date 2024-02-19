//creates a fully solved level and tries to shuffle it

using System;
using System.Collections.Generic;
using System.Linq;

public class LevelCreatorShuffling {
    private List<BallType> allBallsTypes;
    private List<Flask> flasks;
    private Level level;
    private float sameTypeProbability;

    public Level Create(int flasksCount, int ballsCountInFlask, int sameTypeProbability) {
        this.sameTypeProbability = sameTypeProbability;
        allBallsTypes = new List<BallType>((BallType[]) Enum.GetValues(typeof(BallType)));
        flasks = new List<Flask>();
        level = new Level();


        //create fully loaded
        for (var i = 0; i < flasksCount; i++) {
            var f = new Flask(ballsCountInFlask);
            for (var j = 0; j < ballsCountInFlask; j++) {
                f.AddBall(allBallsTypes[i]);
            }

            flasks.Add(f);
        }

        //add 2 empty flask
        flasks.Add(new Flask(ballsCountInFlask));
        flasks.Add(new Flask(ballsCountInFlask));

        //now shuffle them
        var shuffleCount = 100;
        //while (IsThereCompletedFlask()) {
        while (shuffleCount != 0) {
            Shuffle();
            shuffleCount--;
        }

        return level;
    }

    private void Shuffle() {

        
    }

    private bool IsThereCompletedFlask() {
        return flasks.Any(f => f.IsCompleted());
    }
}