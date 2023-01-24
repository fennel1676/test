#include "StdAfx.h"
#include "MsgPortDuplicationEvent.h"

using namespace Message;

CMsgPortDuplicationEvent::CMsgPortDuplicationEvent(void)
{
	m_nMessageType = 2;
	m_nMessageCommand = 18;
	m_nPort=0;
}

CMsgPortDuplicationEvent::~CMsgPortDuplicationEvent(void)
{
}

const CString CMsgPortDuplicationEvent::GetMsg()
{
	CString msg;
	msg.Format(
		_T("<INFO>")"\r\n"
		_T("<PORT>%d</PORT>")"\r\n"
		_T("<HPANELID>%s</HPANELID>")"\r\n"
		_T("<UNIQUEID>%s</UNIQUEID>")"\r\n"
		_T("<RESULT1>%s</RESULT1>")"\r\n"
		_T("<RESULT2>%s</RESULT2>")"\r\n"
		_T("<RESULT3>%s</RESULT3>")"\r\n"
		_T("</INFO>"),m_nPort, m_strH_PanelID, m_strUniqueID, m_strResult1, m_strResult2, m_strResult3);
	return msg;
}
