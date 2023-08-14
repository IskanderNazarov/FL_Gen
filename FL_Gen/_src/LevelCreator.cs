using System;
using System.Collections.Generic;

public class LevelCreator {
    private Dictionary<BallType, int> availableBalls;
    private List<BallType> allBallsTypes;

    /// <summary>
    /// Creates a level with given parameters
    /// </summary>
    /// <param name="flasksCount">Flasks count in level (no counting 2 empty flasks)</param>
    /// <param name="ballsCountInFlask"></param>
    /// <param name="colorBlockProb">Probability of big several colors in row (0 -100)</param>
    /// <returns></returns>
    public Level Create(int flasksCount, int ballsCountInFlask, int colorBlockProb) {
        allBallsTypes = new List<BallType>((BallType[]) Enum.GetValues(typeof(BallType)));


        //initialize
        var flasks = new List<Flask>();
        for (var i = 0; i < flasksCount; i++) {
            flasks.Add(new Flask());
        }

        for (var i = 0; i < flasksCount; i++) {
            availableBalls.Add(allBallsTypes[i], ballsCountInFlask);
        }
        //create a list of available balls for the current level
        /*var allBalls = new List<BallType>();
        for (var i = 0; i < flasksCount; i++) {
            for (var j = 0; j < ballsCountInFlask; j++) {
                allBalls.Add(types[i]);
            }
        }
        allBalls.Shuffle();*/


        var ballIndex = 0;
        foreach (var flask in flasks) {
            for (var i = 0; i < ballsCountInFlask; i++) {
                //flask.Add(allBalls[ballIndex]);
                flask.AddBall(CalculateBallForFlask(flask, colorBlockProb));
                ballIndex++;
            }
        }

        var level = new Level {
            ballCount = ballsCountInFlask,
            flasks = flasks
        };

        return level;
    }

    private BallType CalculateBallForFlask(Flask flask, int blockCountProbability) {
        var p = blockCountProbability / 100f;
        var rand = new Random();

        //only balls which count is not 0
        var ballsReadyToAdd = new List<BallType>();
        foreach (var pair in availableBalls) {
            if (pair.Value > 0) {
                ballsReadyToAdd.Add(pair.Key);
            }
        }

        BallType ball;
        if (flask.IsEmpty()) {//if flask empty - just add random ball
            ball = ballsReadyToAdd[rand.Next(0, ballsReadyToAdd.Count)];
        }
        else { //if not empty - then get top ball with given probability or random ball.
            var topBall = flask.balls[flask.balls.Count - 1];
            ball = rand.NextDouble() >= p && ballsReadyToAdd.Contains(topBall) ? topBall : ballsReadyToAdd[rand.Next(0, ballsReadyToAdd.Count)];
        }

        availableBalls[ball] = availableBalls[ball] - 1; //decrease available balls count
        return ball;
    }
}