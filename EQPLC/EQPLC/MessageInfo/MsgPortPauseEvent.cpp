#include "StdAfx.h"
#include "MsgPortPauseEvent.h"

using namespace Message;

CMsgPortPauseEvent::CMsgPortPauseEvent(void)
{
	m_nMessageType = 2;
	m_nMessageCommand = 15;
	m_nPort=0;
}

CMsgPortPauseEvent::~CMsgPortPauseEvent(void)
{
}

const CString CMsgPortPauseEvent::GetMsg()
{
	CString msg;
	msg.Format(
		_T("<INFO>")"\r\n"
		_T("<PORT>%d</PORT>")"\r\n"
		_T("</INFO>"),m_nPort);
	return msg;
}
