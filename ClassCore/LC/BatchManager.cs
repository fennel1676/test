using System;
using System.Collections.Generic;
using System.Text;

namespace ClassCore
{
    public class BatchManager
    {
        private eLINE  _moduleLine = eLINE.NOLINE;
        private string _moduleID = "";
        private string _panelID = "";
        private string _uniqueID = "";
        private int    _eventPort = 0;
        private eHPanelIDState _panelIDState = eHPanelIDState.NONE;
        private eUniqueIDState _uniqueIDState = eUniqueIDState.NONE;
        private eBatchIDState _batchIDState = eBatchIDState.NONE;

        public List<BatchObject> BatchDatas = new List<BatchObject>();
        public List<PortData> PortDatas = new List<PortData>();

        public List<BatchGlassData> BatchGlassIDs = new List<BatchGlassData>();

        public eLINE TARGET_LINE
        {
            get { return _moduleLine; }
            set { _moduleLine = value; }
        }

        public string TARGET_MODULEID
        {
            get { return _moduleID; }
            set { _moduleID = value; }
        }

        public int EVENT_PORT
        {
            get { return _eventPort; }
            set { if (value > 0) _eventPort = ((value - 1) % 2);}
        }

        public eHPanelIDState PANELID_STATE
        {
            get { return _panelIDState; }
            set { _panelIDState = value; }
        }
        public eUniqueIDState UNIQUEID_STATE
        {
            get { return _uniqueIDState; }
            set { _uniqueIDState = value; }
        }
        public eBatchIDState BATCHID_STATE
        {
            get { return _batchIDState; }
            set { _batchIDState = value; }          
        }
    }
}
