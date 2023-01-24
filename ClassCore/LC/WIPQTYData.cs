using System;
using System.Collections.Generic;
using System.Text;

namespace ClassCore
{
    public class WIPQTYData
    {
        public int line = 0;
        public int WipQty = 0;
        private int _plc1Qty = 0;
        private int _plc2Qty = 0;


        public int SET_PLC1QTY
        {
            get { return _plc1Qty; }             
            set { _plc1Qty = value; }            
        }

        public int SET_PLC2QTY
        {
            get { return _plc2Qty; }
            set { _plc2Qty = value; }
        }

        public bool BOOL_WIPQTY
        {
            get { return (this._plc1Qty + this._plc2Qty) < this.WipQty ? true : false; }
        }
    }
}
