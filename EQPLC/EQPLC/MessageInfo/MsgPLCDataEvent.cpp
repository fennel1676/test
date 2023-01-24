#include "StdAfx.h"
#include "MsgPLCDataEvent.h"

using namespace Message;

CMsgPLCDataEvent::CMsgPLCDataEvent(void)
{
	m_nMessageType = 2;
	m_nMessageCommand = 21;
	m_nPort = 0;
	m_nCommandID = 0;
	m_nByWho = 0;
	m_strCSTID = "";
	m_nMap_Stif = 0;
	m_nStart_Stif = 0;
}

CMsgPLCDataEvent::~CMsgPLCDataEvent(void)
{
}

const CString CMsgPLCDataEvent::GetMsg()
{
	CString msg;
	msg.Format(
		_T("<INFO>")"\r\n"
		_T("<PORT>%d</PORT>")"\r\n"
		_T("<COMMANDID>%d</COMMANDID>")"\r\n"
		_T("<BYWHO>%d</BYWHO>")"\r\n"
		_T("<CSTID>%s</CSTID>")"\r\n"
		_T("<MAP_STIF>%d</MAP_STIF>")"\r\n"
		_T("<START_STIF>%d</START_STIF>")"\r\n"
		_T("</INFO>"),m_nPort, m_nCommandID, m_nByWho, m_strCSTID, m_nMap_Stif, m_nStart_Stif);
	return msg;
}
