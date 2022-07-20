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
        public void AddObservation(MeansOfObservation observation);
        public void DeleteObservation(int code);
        public List<MeansOfObservation> ShowAllObservation();
        public List<MeansOfObservation> ShowObservationByType(types t);
        public List<MeansOfObservation> ShowObservationSortedByRange();
        public MeansOfObservation ObservationWithFarthestRangeByMinimalFieldOfView(double fieldOfVision);



    }
}
