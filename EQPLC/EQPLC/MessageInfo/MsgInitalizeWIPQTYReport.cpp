#include "StdAfx.h"
#include "MsgInitalizeWIPQTYReport.h"

using namespace Message;

CMsgInitalizeWIPQTYReport::CMsgInitalizeWIPQTYReport(void)
{
	m_nMessageType = 2;
	m_nMessageCommand = 14;
}

CMsgInitalizeWIPQTYReport::~CMsgInitalizeWIPQTYReport(void)
{
}


const CString CMsgInitalizeWIPQTYReport::GetMsg()
{
	CString msg;
	msg.Format(
		_T("<INFO>")_T("\n")
		_T("<WIPQTY1P1>%s</WIPQTY1P1>")_T("\n")
		_T("<WIPQTY1P2>%s</WIPQTY1P2>")_T("\n")
		_T("<WIPQTY2P1>%s</WIPQTY2P1>")_T("\n")
		_T("<WIPQTY2P2>%s</WIPQTY2P2>")_T("\n")
		_T("</INFO>"), strWIPQTY1PLC1, strWIPQTY1PLC2, strWIPQTY2PLC1, strWIPQTY2PLC2);
	return msg;
}

