#include "StdAfx.h"
#include "MsgManualDispatchEvent.h"

using namespace Message;

CMsgManualDispatchEvent::CMsgManualDispatchEvent(void)
{
	m_nMessageType = 2;
	m_nMessageCommand = 5;
}

CMsgManualDispatchEvent::~CMsgManualDispatchEvent(void)
{
}

const CString CMsgManualDispatchEvent::GetMsg()
{
	CString msg, strData;
	msg = _T("<INFO>");

	for(int i = 0; i < 5; i++)
	{
		strData.Format(
			_T("<RULE>")
				_T("<NO>%d</NO>")
				_T("<DISPATCH>%d</DISPATCH>")
				_T("<DEVICEID>%s</DEVICEID>")
				_T("<RUNLINE>%d</RUNLINE>")
				_T("<TARGET>%d</TARGET>")
			_T("</RULE>")
			, stManualDispatch[i].nUnitNo, stManualDispatch[i].nDispatchOption, stManualDispatch[i].szDeviceID
			, stManualDispatch[i].nRunline, stManualDispatch[i].nTarget);

		msg += strData;
	}

	msg += _T("</INFO>");

	return msg;
}