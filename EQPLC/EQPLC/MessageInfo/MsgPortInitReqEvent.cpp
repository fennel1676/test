#include "StdAfx.h"
#include "MsgPortInitReqEvent.h"

using namespace Message;

CMsgPortInitReqEvent::CMsgPortInitReqEvent(void)
{
	m_nMessageType = 2;
	m_nMessageCommand = 17;
	m_nPort=0;
}

CMsgPortInitReqEvent::~CMsgPortInitReqEvent(void)
{
}

const CString CMsgPortInitReqEvent::GetMsg()
{
	CString msg;
	msg.Format(
		_T("<INFO>")"\r\n"
		_T("<PORT>%d</PORT>")"\r\n"
		_T("</INFO>"),m_nPort);
	return msg;
}
