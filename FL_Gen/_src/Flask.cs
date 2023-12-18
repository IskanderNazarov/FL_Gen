using System.Collections.Generic;

public class Flask {
    public List<BallType> balls { get; }
    public int maxBallsCount { get; }

    public Flask(int maxBallsCount) {
        balls = new List<BallType>();
        this.maxBallsCount = maxBallsCount;
    }

    public Flask(Flask flasksCopy) {
        balls = new List<BallType>();
        foreach (var ball in flasksCopy.balls) {
            balls.Add(ball);
        }

        maxBallsCount = flasksCopy.maxBallsCount;
    }

    public void AddBall(BallType ball) {
        balls.Add(ball);
    }

    public void RemoveTopBall() {
        if (!IsEmpty()) {
            balls.RemoveAt(balls.Count - 1);
        }
    }
    
    public BallType GetTopBall() {
        return IsEmpty() ? default : balls[balls.Count - 1];
    }

    public bool IsEmpty() {
        return balls.Count == 0;
    }
    
    public bool IsFull() {
        return balls.Count == maxBallsCount;
    }

    /// <summary>
    /// Shows if the flask fully filled with one-color balls 
    /// </summary>
    public bool IsCompleted() {                                                                                               
        if (!IsFull()) return false;
        
        var isOneColor = true;
        var firstBall = balls[0];
        foreach (var ballType in balls) {
            isOneColor &= firstBall == ballType;
        }

        return isOneColor;
    }
}