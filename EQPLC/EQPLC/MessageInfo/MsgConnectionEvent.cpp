#include "StdAfx.h"
#include "MsgConnectionEvent.h"

using namespace Message;

CMsgConnectionEvent::CMsgConnectionEvent(void)
{
	m_nMessageType = 2;
	m_nMessageCommand = 19;
	m_nResult=0;
}

CMsgConnectionEvent::~CMsgConnectionEvent(void)
{
}

const CString CMsgConnectionEvent::GetMsg()
{
	CString msg;
	msg.Format(
		_T("<INFO>")"\r\n"
		_T("<RESULT>%d</RESULT>")"\r\n"
		_T("</INFO>"),m_nResult);
	return msg;
}
