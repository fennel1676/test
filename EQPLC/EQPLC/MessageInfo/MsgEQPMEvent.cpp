#include "StdAfx.h"
#include "MsgEQPMEvent.h"

using namespace Message;

CMsgEQPMEvent::CMsgEQPMEvent(void)
{
	m_nMessageType = 2;
	m_nMessageCommand = 9;
}

CMsgEQPMEvent::~CMsgEQPMEvent(void)
{
}

const CString CMsgEQPMEvent::GetMsg()
{
	CString msg;
	msg.Format(
		_T("<INFO>")_T("\n")
			_T("<PM>%s</PM>")_T("\n")
		_T("</INFO>")
		, strPMCode);

	return msg;
}