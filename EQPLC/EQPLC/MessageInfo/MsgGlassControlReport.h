#pragma once
#include "../MessageInfo.h"

namespace Message
{
class CMsgGlassControlReport : public IMessageInfo
{
public:
	CMsgGlassControlReport(void);
	virtual ~CMsgGlassControlReport(void);

public:
	virtual const CString GetMsg();
	virtual bool ParseMsg(const CString& strXML) { return false; }

public:
	CString strUnitName;
	CString strEventID;
	CString strHPanelID;
	CString strBrokenCode;
};
}