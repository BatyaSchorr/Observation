using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservationDAL
{
    public class DataSource
    {
        public static List<MeansOfObservation> Observation = new List<MeansOfObservation>(10);
        public static void Initialize()
        {
            MeansOfObservation observation1 = new MeansOfObservation();
            MeansOfObservation observation2 = new MeansOfObservation();

            Observation.Add(observation1);
            
        }
    }
}
