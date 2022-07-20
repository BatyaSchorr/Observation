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
        public int Code { get; set; }
        public types Type { get; set; }
        public double Range { get; set; }
        public double FieldOfVision { get; set; }

        public MeansOfObservation()
        {
            this.Code = 0;
            this.Type = types.Camera;
            this.Range = 32.9;
            this.FieldOfVision = 90;
        }

        public MeansOfObservation(int code, types type, double range, double fieldOfVision)
        {
            this.Code = code;
            this.Type = type;
            this.Range = range;
            this.FieldOfVision = fieldOfVision;
        }

    }
}
