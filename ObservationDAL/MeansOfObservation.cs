using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservationDAL
{
    public enum types { binoculars, telescope, Camera };

    public class MeansOfObservation
    {
        public int code { get; set; }
        public types Type { get; set; }
        public double Range { get; set; }
        public double FieldOfVision { get; set; }

    }
}
