#pragma once
#include "../MessageInfo.h"

namespace Message
{
class CMsgAlarmReport : public IMessageInfo
{
public:
	CMsgAlarmReport(void);
	CMsgAlarmReport(bool bType);
	virtual ~CMsgAlarmReport(void);

public:
	virtual const CString GetMsg();
	virtual bool ParseMsg(const CString& strXML) { return false; }

public:
	CString strUnitName;
	CString strAlarmValue;
};
}