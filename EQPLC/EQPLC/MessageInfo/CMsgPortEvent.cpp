#include "StdAfx.h"
#include "CMsgPortEvent.h"

using namespace Message;

CMsgPortEvent::CMsgPortEvent(void)
{
	m_nMessageType = 2;
	m_nMessageCommand = 12;
	nPortNum=0;
	nEventID=0;
	strPortID="";
	nPortState=0;
	nPortType=0;
	strPortMode="";
	nSortType=0;
	nCSTDemand=0;
	strCSTID="";
	strCSTType="";
	strMat_Stif="";
	strCur_Stif="";
	nBatch_Order=0;
	nByWho=0;
	nReply=0;
}

CMsgPortEvent::~CMsgPortEvent(void)
{
}

const CString CMsgPortEvent::GetMsg()
{
	CString msg;
	msg.Format(
		_T("<INFO>")_T("\n")
		_T("<PORT>%d</PORT>")_T("\n")
		_T("<EVENTID>%d</EVENTID>")_T("\n")
		_T("<PORTID>%s</PORTID>")_T("\n")
		_T("<PORT_STATE>%d</PORT_STATE>")_T("\n")
		_T("<PORT_TYPE>%d</PORT_TYPE>")_T("\n")
		_T("<PORT_MODE>%s</PORT_MODE>")_T("\n")
		_T("<SORT_TYPE>%d</SORT_TYPE>")_T("\n")
		_T("<CST_DEMAND>%d</CST_DEMAND>")_T("\n")
		_T("<CSTID>%s</CSTID>")_T("\n")
		_T("<CST_TYPE>%s</CST_TYPE>")_T("\n")
		_T("<MAT_STIF>%s</MAT_STIF>")_T("\n")
		_T("<CUR_STIF>%s</CUR_STIF>")_T("\n")
		_T("<BATCH_ORDER>%d</BATCH_ORDER>")_T("\n")
		_T("<BYWHO>%d</BYWHO>")_T("\n")
		_T("<REPLY>%d</REPLY>")_T("\n")
		_T("</INFO>"),nPortNum,nEventID,strPortID,nPortState,nPortType,strPortMode,nSortType,nCSTDemand,
		strCSTID,strCSTType,strMat_Stif,strCur_Stif,nBatch_Order,nByWho,nReply);
		return msg;
}
