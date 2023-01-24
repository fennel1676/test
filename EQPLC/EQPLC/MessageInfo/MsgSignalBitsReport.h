#pragma once

#include "../MessageInfo.h"

namespace Message
{
class CMsgSignalBitsReport : public IMessageInfo
{
public:
	CMsgSignalBitsReport(void);
	CMsgSignalBitsReport(bool bType);
	virtual ~CMsgSignalBitsReport(void);

public:
	virtual const CString GetMsg();
	virtual bool ParseMsg(const CString& strXML) { return false; }

public:
	CString strUnitName;
	CString strSignalBit;
	CString strRefuseCode;
};
}