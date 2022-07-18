﻿using System;
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
        public List<MeansOfObservation> ShowObservationByType(string ch);
        public List<MeansOfObservation> ShowObservationSortedByRange(double range);
        public MeansOfObservation ObservationWithFarthestRangeByMinimalFieldOfView(double fieldOfVision);



    }
}
