# XC Team Scoring

Cross country running is both an individual and a team sport. Individuals are ranked based on the order that they cross the finish line. A team score is calculated by assigning points to individual team members, and then summing the points of the team’s top five runners. Teams are then ranked by the order of their team score from lowest to highest. The rules for awarding points to individual team members, and calculating a team score are as follows:

- A team must have at least five runners in order to earn points and receive a team score. If a team has less than five runners, those runners cannot earn points and the team is excluded from the team results.
- Only the top seven runners from each team earn points; if a team has more than seven runners, the additional runners do not earn points and are excluded from the team results.
- Each team's score is calculated by adding up the points earned by the top five runners on that team.
- In the event of a tie where multiple teams earn the same team score, the 6th-place runner from each of those teams is the tiebreaker (i.e., the team whose 6th-place runner earned a lower point value wins).

Here is an example that shows the finish place, along with points awarded and total team scores for a race with participants from four different teams:

| Place | Athlete Name     | Team Name        | Elapsed Time | Points |
| ----- | ---------------- | ---------------- | ------------ | ------ |
| 1     | Noah Perry       | Central High     | 17:35        | 1      |
| 2     | Jake Sandefur    | Hamilton Academy | 17:43        |
| 3     | Sam Gibbs        | Springfield      | 17:44        | 2      |
| 4     | David Sander     | Springfield      | 17:59        | 3      |
| 5     | Lucas Webster    | Central High     | 18:19        | 4      |
| 6     | Jack Hatton Gray | County           | 18:24        | 5      |
| 7     | Logan Walters    | Central High     | 18:40        | 6      |
| 8     | Bradley Davis    | Central High     | 18:54        | 7      |
| 9     | Cameron Brockman | Springfield      | 19:03        | 8      |
| 10    | James Springer   | Gray County      | 19:08        | 9      |
| 11    | Dylan Hasler     | Central High     | 19:10        | 10     |
| 12    | Shawn Berger     | Hamilton Academy | 19:23        |
| 13    | Austin Schwartz  | Springfield      | 19:31        | 11     |
| 14    | Tyler Bergman    | Springfield      | 19:34        | 12     |
| 15    | Brandon Schultz  | Central High     | 19:35        | 13     |
| 16    | Evan Holtz       | Gray County      | 19:36        | 14     |
| 17    | Josh Obermeyer   | Springfield      | 19:44        | 15     |
| 18    | Alex Morris      | Central High     | 19:50        | 16     |
| 19    | William Cook     | Gray County      | 19:56        | 17     |
| 20    | Justin Holloway  | Springfield      | 19:57        | 18     |
| 21    | Hunter Kohlsmith | Gray County      | 19:58        | 19     |
| 22    | Anthony Rone     | Gray County      | 20:05        | 20     |
| 23    | Ethan Conrad     | Central High     | 20:09        |
| 24    | Matthew McCain   | Gray County      | 20:26        | 21     |

Team Scores
Place | Team Name | Scorers | Total Points
----- | --------- | ------- | ------------
1 | Central High | 1+4+6+7+10 (13+16) | 28
2 | Springfield | 2+3+8+11+12 (15+18) | 36
3 | Gray County | 5+9+14+17+19 (20+21) | 64

- Jake Sandefur and Shawn Berger from Hamilton Academy did not receive points because their team has less than five runners. Also notice that Hamilton Academy is not listed in the team scores.
- Ethan Conrad from Central High did not receive points because he was the 8th place finisher for his team. Only the top seven places per team can earn points.

Implement the GetTeamScores() function shown below. The function accepts a list of race participants who finished the race, and returns a list of team scores. You can assume that the list of race participants is already ordered by finish place. Your function should return a list of team scores ordered by the team finish place (i.e., the winning team should be index 0). Each TeamScore element in the returned list should include the Team Name, the Total Points earned by the team, and a list of point values for all participants on the team who earned points.

    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace XCTeamScores
    {
        public class Participant
            {
            public string AthleteName;
            public string TeamName;
            public string Duration;
        }
        public class TeamScore
        {
            public string TeamName;
            public int TotalPoints;
            public List<int> ParticipatePoints;

            public TeamScore(string teamName)
            {
                TeamName = teamName;
                TotalPoints = 0;
                ParticipatePoints = new List<int>();
            }
        }

        public class ScoreManager
        {
            public List<TeamScore> GetTeamScores(List<Participant> participants)
            {
                // implement this function
            }
        }
    }
