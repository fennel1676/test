#include "StdAfx.h"
#include "MsgPanelIDEvent.h"

using namespace Message;

CMsgPanelIDEvent::CMsgPanelIDEvent(void)
{
	m_nMessageType = 2;
	m_nMessageCommand = 13;
	m_nPort=0;
}

CMsgPanelIDEvent::~CMsgPanelIDEvent(void)
{
}

const CString CMsgPanelIDEvent::GetMsg()
{
	CString msg;
	msg.Format(
		_T("<INFO>")"\r\n"
		_T("<PORT>%d</PORT>")"\r\n"
		_T("</INFO>"),m_nPort);
	return msg;
}
