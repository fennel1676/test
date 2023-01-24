#pragma once
#include "../MessageInfo.h"

namespace Message
{
class CMsgUnitStateReport : public IMessageInfo
{
public:
	CMsgUnitStateReport(void);
	virtual ~CMsgUnitStateReport(void);

public:
	virtual const CString GetMsg();
	virtual bool ParseMsg(const CString& strXML) { return false; }

public:
	CString strUnitName;
	CString strPMCode;
	CString strPauseCode;
	CString strByWho;
	//CString strExist;
	CString strEQState;
	CString strProcessState;
	CString strByWhoEQ;
	CString strByWhoProcess;
};
}