#include "StdAfx.h"
#include "MsgAlarmReport.h"

using namespace Message;

CMsgAlarmReport::CMsgAlarmReport(void)
{
	m_nMessageType = 3;
	m_nMessageCommand = 2;
}

//«ÿ¡¶
CMsgAlarmReport::CMsgAlarmReport(bool bType)
{
	m_nMessageType = 3;
	m_nMessageCommand = (bType == true ? 2 : 3);
}

CMsgAlarmReport::~CMsgAlarmReport(void)
{
}

const CString CMsgAlarmReport::GetMsg()
{
	
	if(strAlarmValue.IsEmpty())
		return _T("");

	CString msg;
	msg.Format(
		_T("<INFO>")_T("\n")
			_T("<VALUE>%s</VALUE>")_T("\n")	
		_T("</INFO>"), strAlarmValue);

	return msg;
}
