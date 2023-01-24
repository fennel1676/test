#pragma once

#include "../MessageInfo.h"

namespace Message
{
class CMsgEQConstantCommand : public IMessageInfo
{
public:
	struct ECID_INFO
	{
		short nECID;
		short nECDEF;
		short nECSLL;
		short nECSUL;
		short nECWLL;
		short nECWUL;
	};
public:
	CMsgEQConstantCommand(void);
	virtual ~CMsgEQConstantCommand(void);

public:
	virtual const CString GetMsg() { return _T(""); }
	virtual bool ParseMsg(const CString& strXML);

public:
	int nCommandID;
	ECID_INFO stECIDInfo[15];
};
}
