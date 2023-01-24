#include "StdAfx.h"
#include "MsgEQOnlineParameterEvent.h"

using namespace Message;

CMsgEQOnlineParameterEvent::CMsgEQOnlineParameterEvent(void)
{
	m_nMessageType = 2;
	m_nMessageCommand = 7;
}

CMsgEQOnlineParameterEvent::~CMsgEQOnlineParameterEvent(void)
{
}

const CString CMsgEQOnlineParameterEvent::GetMsg()
{
	CString msg=_T("");
	CString strMode = _T("");
	
	/*for(int i = 0; i < 5; i++)
	{
		msg.Format(
				_T("<VCR>%d</VCR>")
				_T("<WAIT>%d</WAIT>")
			, nVCRMode[i], nWaitTime[i]);

		strMode += msg;
	}*/


	msg=_T("");
	msg.Format(_T("<INFO>")
					_T("<ID>%d</ID>")
					_T("<JUDGEMENT>%d</JUDGEMENT>")
					_T("<NO>%d</NO>")
					_T("<VCR>%d</VCR>")
					_T("<WAIT>%d</WAIT>")
					_T("<MODE>%d</MODE>")
					_T("<BYWHO>%d</BYWHO>")
				_T("</INFO>")
			, nEventID, nJudgement, nVcrNo, nVCRMode,nWaitTime , nWIPQTYMode, nByWho);

	return msg;
}
