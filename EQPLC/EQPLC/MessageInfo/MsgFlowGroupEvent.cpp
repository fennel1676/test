#include "StdAfx.h"
#include "MsgFlowGroupEvent.h"

using namespace Message;

CMsgFlowGroupEvent::CMsgFlowGroupEvent(void)
{
	m_nMessageType = 2;
	m_nMessageCommand = 2;
}

CMsgFlowGroupEvent::~CMsgFlowGroupEvent(void)
{
}

const CString CMsgFlowGroupEvent::GetMsg()
{
	if(0 != nEventID)		return _T("");

	CString msg;
	msg.Format(
		_T("<INFO>")_T("\n")
			_T("<ID>0</ID>")_T("\n")
			_T("<BODY>%d %d %d %d %d %d %d %d %d %d</BODY>")_T("\n")
		_T("</INFO>"), nOrder[0], nOrder[1], nOrder[2], nOrder[3], nOrder[4],
					   nOrder[5], nOrder[6], nOrder[7], nOrder[8], nOrder[9]);

	return msg;
}
