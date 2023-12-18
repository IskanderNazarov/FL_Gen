using System;
using System.Collections.Generic;

public class LevelCreator {
    private Dictionary<BallType, int> availableBalls;
    private List<BallType> availableBallsList;
    private List<BallType> allBallsTypes;
    private List<Flask> flasks;

    /// <summary>
    /// Creates a level with given parameters
    /// </summary>
    /// <param name="flasksCount">Flasks count in level (no counting 2 empty flasks)</param>
    /// <param name="ballsCountInFlask"></param>
    /// <param name="sameTypeProbability">Probability of big several colors in row (0 -100)</param>
    /// <returns></returns>
    public Level Create(int flasksCount, int ballsCountInFlask, int sameTypeProbability) {
        allBallsTypes = new List<BallType>((BallType[]) Enum.GetValues(typeof(BallType)));


        //initialize
        flasks = new List<Flask>();
        for (var i = 0; i < flasksCount; i++) {
            flasks.Add(new Flask(ballsCountInFlask));
        }

        availableBalls = new Dictionary<BallType, int>();
        availableBallsList = new List<BallType>();
        for (var i = 0; i < flasksCount; i++) {
            availableBalls.Add(allBallsTypes[i], ballsCountInFlask);

            for (var j = 0; j < ballsCountInFlask; j++) {
                availableBallsList.Add(allBallsTypes[i]);
            }
        }


        //pass through the balls and try add each ball on its place
        while (availableBallsList.Count > 0) {
            availableBallsList.Shuffle();
            var ball = availableBallsList[availableBallsList.Count - 1];
            availableBallsList.RemoveAt(availableBallsList.Count - 1);

            AddBallToFlask(ball, sameTypeProbability);
        }


        /*foreach (var flask in flasks) {
            for (var i = 0; i < ballsCountInFlask; i++) {
                //flask.Add(allBalls[ballIndex]);
                AddBallToFlask(flask, colorBlockProb);
            }
        }*/

        var level = new Level {
            ballCount = ballsCountInFlask,
            flasks = flasks
        };

        return level;
    }

    //--------------------------------------------------------------------

    //find flask for the ball and put the ball inside
    //sameTypeProbability - probability with which the ball should be placed on the same ball
    private void AddBallToFlask(BallType ball, int sameTypeProbability) {
        var rand = new Random();
        var randomValue = rand.NextDouble();
        var p = sameTypeProbability / 100f;
        var addToSameType = randomValue < p;
        /*Console.WriteLine($"randomValue: {randomValue}");
        Console.WriteLine($"p: {p}");
        Console.WriteLine($"---------");
        flasks.Shuffle();*/

        //if there is an empty flask - add the ball to it
        /*foreach (var flask in flasks) {
            if (flask.IsEmpty()) {
                flask.AddBall(ball);
                return;
            }
        }*/


        //then try to add the ball on the same ball
        if (addToSameType) {
            foreach (var flask in flasks) {
                //if (!flask.IsEmpty() && !flask.IsFull() && flask.GetTopBall() == ball) {
                if (flask.IsEmpty() || !flask.IsFull() && flask.GetTopBall() == ball) {
                    flask.AddBall(ball);
                    if (flask.IsCompleted()) {
                        flask.RemoveTopBall();
                    }
                    else {
                        return;
                    }
                }
            }
        }


        //then try to add the ball on a different ball
        flasks.Shuffle();
        foreach (var flask in flasks) {
            if (!flask.IsEmpty() && !flask.IsFull() && flask.GetTopBall() != ball) {
                flask.AddBall(ball);
                return;
            }
        }


        //after all try to add to a random position in a random flask
        flasks.Shuffle();
        foreach (var flask in flasks) {
            if (!flask.IsFull()) {
                flask.AddBall(ball);
                return;
            }
        }
    }

    //--------------------------------------------------------------------

    private void AddBallToFlask(Flask flask, int blockCountProbability) {
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
        if (flask.IsEmpty()) {
            //if flask empty - just add random ball
            ball = ballsReadyToAdd[rand.Next(0, ballsReadyToAdd.Count)];
        }
        else {
            //if not empty - then get top ball with given probability or random ball.
            var topBall = flask.balls[flask.balls.Count - 1];
            var randValue = rand.NextDouble();
            /*Console.WriteLine($"P: {p}");
            Console.WriteLine($"randValue: {randValue}");
            Console.WriteLine($"--------");*/
            ball = randValue <= p && ballsReadyToAdd.Contains(topBall) ? topBall : ballsReadyToAdd[rand.Next(0, ballsReadyToAdd.Count)];
            flask.AddBall(ball);
            if (flask.IsCompleted()) {
                //if added ball completes the flask then remove it and add another random flask
                Console.WriteLine("111");
                flask.RemoveTopBall();
                Console.WriteLine("222");


                //find a random ball which is not the same as already generated 'ball'
                Console.WriteLine("333, count: " + ballsReadyToAdd.Count);
                ballsReadyToAdd.Shuffle();
                Console.WriteLine("444");
                ballsReadyToAdd.Remove(ball);
                Console.WriteLine("555");
                flask.AddBall(ballsReadyToAdd[0]);
                Console.WriteLine("666");
            }
        }

        availableBalls[ball] = availableBalls[ball] - 1; //decrease available balls count
        flask.AddBall(ball);
    }
}