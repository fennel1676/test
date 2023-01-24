#pragma once

#include "../MessageInfo.h"

namespace Message
{
class CMsgAlarmResetCommand : public IMessageInfo
{
public:
	struct CLEAR_ALARM
	{
		short nUnitNo;
		short nAlarmNo;
	};

public:
	CMsgAlarmResetCommand(void);
	virtual ~CMsgAlarmResetCommand(void);

public:
	virtual const CString GetMsg() { return _T(""); }
	virtual bool ParseMsg(const CString& strXML);

public:
	short nCommandID;
	short nCount;
	short nByWho;
	CLEAR_ALARM stClearAlarm[20];
};
}