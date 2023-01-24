#include "StdAfx.h"
#include "MsgSignalBitsReport.h"
#include "../XMLParser.h"

using namespace Message;

CMsgSignalBitsReport::CMsgSignalBitsReport(void)
{
	m_nMessageType = 3;
	m_nMessageCommand = 7;
}

CMsgSignalBitsReport::CMsgSignalBitsReport(bool bType)
{
	m_nMessageType = 3;
	m_nMessageCommand = (bType == true ? 7 : 8);
}

CMsgSignalBitsReport::~CMsgSignalBitsReport(void)
{
}

const CString CMsgSignalBitsReport::GetMsg()
{
	CString msg;
	msg.Format(
		_T("<INFO>")"\r\n"
			_T("<SIGNAL>%s</SIGNAL>")"\r\n"	
			_T("<REFUSE>%s</REFUSE>")"\r\n"
		_T("</INFO>"), strSignalBit, strRefuseCode);

	return msg;
}
