#include "StdAfx.h"
#include "MsgGlassControlReport.h"

using namespace Message;

CMsgGlassControlReport::CMsgGlassControlReport(void)
{
	m_nMessageType = 3;
	m_nMessageCommand = 6;
}

CMsgGlassControlReport::~CMsgGlassControlReport(void)
{
}

const CString CMsgGlassControlReport::GetMsg()
{
	if(strEventID.IsEmpty() || strHPanelID.IsEmpty())
		return _T("");

	CString msg;
	msg.Format(
		_T("<INFO>")_T("\n")
			_T("<ID>%s</ID>")_T("\n")
			_T("<H_PANELID>%s</H_PANELID>")_T("\n")
			_T("<BROKEN>%s</BROKEN>")_T("\n")
		_T("</INFO>"), strEventID, strHPanelID, strBrokenCode);

	return msg;
}
