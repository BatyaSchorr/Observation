using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObservationDAL;

namespace ObservationBL
{
   public class BL : IBL
    {
        public void AddObservation(MeansOfObservation observation)
        {
            DataSource.Observation.Add(observation);
        }
        public void DeleteObservation(int code)
        {
            var ob = DataSource.Observation.Find(x => x.Code == code);
            if (ob.Equals(null))
                throw new Exception("this id was not found");
            DataSource.Observation.Remove(ob);
        }
        public List<MeansOfObservation> ShowAllObservation()
        {
            return DataSource.Observation.ToList();
        }
        public List<MeansOfObservation> ShowObservationByType(types t)
        {
            List<MeansOfObservation> MeansOfObservationList = new List<MeansOfObservation>();
            foreach (MeansOfObservation ob in DataSource.Observation)
            {
                if (ob.Type.Equals(t))
                    MeansOfObservationList.Add(ob);
            }
            return MeansOfObservationList.ToList();
        }
        public List<MeansOfObservation> ShowObservationSortedByRange()
        {
            var sortList = from ob in DataSource.Observation
                        orderby ob.Range
                           select ob;
            return sortList.ToList();
        }
        public MeansOfObservation ObservationWithFarthestRangeByMinimalFieldOfView(double fieldOfVision) 
        {
            var sortList = from ob in DataSource.Observation
                           orderby ob.Range descending
                           select ob;
            var obWithFarthestRange = sortList.First();
            if (obWithFarthestRange.FieldOfVision >= fieldOfVision)
                return obWithFarthestRange;
            return default(MeansOfObservation);
        }

    }
}
