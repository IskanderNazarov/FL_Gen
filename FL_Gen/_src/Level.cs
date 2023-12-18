using System.Collections.Generic;
using System.Text;

public class Level {
    public int ballCount { get; set; }
    public List<Flask> flasks;

    public override string ToString() {
        var sb = new StringBuilder();
        sb.Append(flasks.Count + 2);//actual flasks count
        sb.Append('\n');
        sb.Append(ballCount);
        sb.Append('\n');

        foreach (var flask in flasks) {
            foreach (var ballType in flask.balls) {
                sb.Append((int) ballType + 1);
                sb.Append(' ');
            }

            sb.Append('\n');
        }

        //add 2 empty flasks
        for (var i = 0; i < 2; i++) {
            for (var j = 0; j < ballCount; j++) {
                sb.Append(0);
                sb.Append(' ');
            }

            sb.Append('\n');
        }

        return sb.ToString();
    }
}