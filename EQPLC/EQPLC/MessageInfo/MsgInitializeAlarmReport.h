#pragma once

#include "../MessageInfo.h"

namespace Message
{
class CMsgInitializeAlarmReport : public IMessageInfo
{
public:
	struct INIT_ALARM
	{
		int nAlarmUnit;
		int nAlarmValue[32];
	};

public:
	CMsgInitializeAlarmReport(void);
	virtual ~CMsgInitializeAlarmReport(void);

public:
	virtual const CString GetMsg();
	virtual bool ParseMsg(const CString& strXML) { return false; }
	void AddMaster(int nAlarmMaster, int nAlarmValue, BOOL bSet);
	void AddUnit(int nAlarmUnit, int nAlarmValue, BOOL bSet);

public:
	int m_nUnitCount;
	INIT_ALARM m_stMasterAlarm[10];
	INIT_ALARM m_stUnitAlarm[81];
};
}