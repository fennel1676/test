using System;
using System.Collections.Generic;
using System.Text;
using ClassCore;

namespace ClassCore
{
    public class PortData
    {       
        public string EqID = "";
        public string UnitID = "";
        public string ModuleID = "";
        private short _pauseState = 0;
        private int JobNo = 0;

        private eERRCODE _eventCode = eERRCODE.NoError;

        public eLINE TargetLine = eLINE.NOLINE;


        public PortObject Port = new PortObject();
        public CassetteObject Cassette = null;

        public eERRCODE ERROR_CODE
        {
            get { return _eventCode; }
            set { _eventCode = value; }
        }

        public short PAUSE_STATE
        {
            get { return _pauseState; }
            set { _pauseState = value; }
        }

        public int JOB_NUMBER
        {
            get { return JobNo; }
            set { JobNo = value; }
        }

    }
}
