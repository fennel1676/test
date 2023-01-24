#include "StdAfx.h"
#include "MsgPLCSignalEvent.h"

using namespace Message;

CMsgPLCSignalEvent::CMsgPLCSignalEvent(void)
{
	m_nMessageType = 2;
	m_nMessageCommand = 20;
	m_nPort=0;
	m_nSigID=0;
	m_nResult=0;
}

CMsgPLCSignalEvent::~CMsgPLCSignalEvent(void)
{
}

const CString CMsgPLCSignalEvent::GetMsg()
{
	CString msg;
	msg.Format(
		_T("<INFO>")"\r\n"
		_T("<PORT>%d</PORT>")"\r\n"
		_T("<SIGNALID>%d</SIGNALID>")"\r\n"
		_T("<RESULT>%d</RESULT>")"\r\n"
		_T("</INFO>"),m_nPort, m_nSigID, m_nResult);
	return msg;
}
