#pragma once

#include "../MessageInfo.h"

namespace Message
{
class CMsgEQConstantEvent : public IMessageInfo
{
public:
	struct ECID_INFO
	{
		short nECID;
		char szECDEF[4];
		short nECSLL;
		short nECSUL;
		short nECWLL;
		short nECWUL;
	};

public:
	CMsgEQConstantEvent(void);
	virtual ~CMsgEQConstantEvent(void);

public:
	virtual const CString GetMsg();
	virtual bool ParseMsg(const CString& strXML) { return false; }

public:
	ECID_INFO stEQConstant[15];
};
}