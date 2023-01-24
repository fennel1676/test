#include "StdAfx.h"
#include "MsgPortResumeEvent.h"

using namespace Message;

CMsgPortResumeEvent::CMsgPortResumeEvent(void)
{
	m_nMessageType = 2;
	m_nMessageCommand = 16;
	m_nPort=0;
}

CMsgPortResumeEvent::~CMsgPortResumeEvent(void)
{
}

const CString CMsgPortResumeEvent::GetMsg()
{
	CString msg;
	msg.Format(
		_T("<INFO>")"\r\n"
		_T("<PORT>%d</PORT>")"\r\n"
		_T("</INFO>"),m_nPort);
	return msg;
}
