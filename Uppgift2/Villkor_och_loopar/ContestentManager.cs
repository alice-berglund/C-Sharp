using System;
using System.Collections.Generic;

namespace Villkor_och_loopar
{
    public class ContestentManager
    {
        private List<Contestent> contestants = new List<Contestent>();

        public void SaveContestent(Contestent contestent)
        {
            contestants.Add(contestent);
        }

        private int GetTime(Contestent contestent)
        {
            int startHour = contestent.StartHour * 3600;
            int endHour = contestent.EndHour * 3600;
            contestent.EndMinute *= 60;
            contestent.StartMinute *= 60;

            int test = contestent.StartNumber;
            int startTime = startHour + contestent.StartMinute + contestent.StartSecond;
            int endTime = endHour + contestent.EndMinute + contestent.EndSecond;

            int time;

            if (startTime < endTime)
            {
                time = endTime - startTime;
            }
            else
            {
                int hourTime = (24 - contestent.StartHour) + contestent.EndHour;
                hourTime *= 3600;

                startTime = contestent.StartMinute + contestent.StartSecond;
                endTime = contestent.EndMinute + contestent.EndSecond;

                time = (endTime - startTime) + hourTime;
            }

            return time;
        }

        public string GetTheWinners()
        {
            int winner = int.MaxValue;
            int fastestTime = int.MaxValue;
            int second = int.MaxValue;
            int nextFastestTime = int.MaxValue;
            foreach(Contestent contestent in contestants)
            {
                int time = GetTime(contestent);

                if(time < fastestTime)
                {
                    nextFastestTime = fastestTime;

                    second = winner;

                    fastestTime = time;

                    winner = contestent.StartNumber;

                }
                else if(time < nextFastestTime)
                {
                    nextFastestTime = time;

                    second = contestent.StartNumber;
                }

            }

            TimeSpan winningTime = TimeSpan.FromSeconds(fastestTime);

            TimeSpan secondTime = TimeSpan.FromSeconds(nextFastestTime);

            string result = $"The winner is startnummer {winner.ToString()} with the time {winningTime}! \n" +
                $" Second place is startnummer {second.ToString()} with the time {secondTime}!";

            return result;
        }
    }
}
