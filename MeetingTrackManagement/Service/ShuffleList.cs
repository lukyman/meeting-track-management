using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingTrackManagement.Service
{
    public static class ShuffleList
    {
        public static List<E> Shuffle<E>(List<E> listToShuffle)
        {
            List<E> randomList = new List<E>();

            Random r = new Random();
            int randomIndex = 0;
            while (listToShuffle.Count > 0)
            {
                randomIndex = r.Next(0, listToShuffle.Count);
                randomList.Add(listToShuffle[randomIndex]);
                listToShuffle.RemoveAt(randomIndex);
            }

            return randomList;

        }
    }
}
