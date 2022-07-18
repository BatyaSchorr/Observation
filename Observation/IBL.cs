using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObservationDAL;

namespace ObservationBL
{
    public interface IBL
    {
        public void AddObservation(MeansOfObservation Observation);
        public void DeleteObservation(int code);
        public void ShowAllObservation();
        public void ShowObservationByType(string ch);
        public void ShowObservationSortedByRange(double range);
        public void ObservationWithFarthestRangeByMinimalFieldOfView(MeansOfObservation drone);



    }
}
