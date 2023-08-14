using System.Collections.Generic;

public class Flask {
    public List<BallType> balls { get; }

    public Flask() {
        balls = new List<BallType>();
    }
    
    public Flask(List<BallType> flasksCopy) {
        balls = new List<BallType>();
        foreach (var ball in flasksCopy) {
            balls.Add(ball);
        }
    }

    public void AddBall(BallType ball) {
        balls.Add(ball);
    }

    public bool IsEmpty() {
        return balls.Count == 0;
    }
    
    
}