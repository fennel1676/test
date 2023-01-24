#include "StdAfx.h"
#include "MsgUnitStateReport.h"

using namespace Message;

CMsgUnitStateReport::CMsgUnitStateReport(void)
{
	m_nMessageType = 3;
	m_nMessageCommand = 4;
}

CMsgUnitStateReport::~CMsgUnitStateReport(void)
{
}

const CString CMsgUnitStateReport::GetMsg()
{
	if(strEQState.IsEmpty() || strProcessState.IsEmpty())
		return _T("");

	CString msg;
	msg.Format(
		_T("<INFO>")_T("\n")
			_T("<PM>%s</PM>")_T("\n")
			_T("<PAUSE>%s</PAUSE>")_T("\n")
			_T("<BYWHO>%s</BYWHO>")_T("\n")
			//_T("<EXIST>%s</EXIST>")
			_T("<EQ_STATE>%s</EQ_STATE>")_T("\n")
			_T("<PROCESS_STATE>%s</PROCESS_STATE>")_T("\n")
			_T("<EQ_BYWHO>%s</EQ_BYWHO>")_T("\n")
			_T("<PROCESS_BYWHO>%s</PROCESS_BYWHO>")_T("\n")
		_T("</INFO>"), strPMCode, strPauseCode, strByWho, //strExist,
			strEQState, strProcessState, strByWhoEQ, strByWhoProcess);

	return msg;
}
