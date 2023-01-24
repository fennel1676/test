#pragma once

#include "../MessageInfo.h"

namespace Message
{
class CMsgManualDispatchEvent : public IMessageInfo
{
public:
	struct MANUAL_DISPATCH
	{
		short nUnitNo;
		short nDispatchOption;
		char szDeviceID[24];
		short nRunline;
		long nTarget;
	};

public:
	CMsgManualDispatchEvent(void);
	virtual ~CMsgManualDispatchEvent(void);

public:
	virtual const CString GetMsg();
	virtual bool ParseMsg(const CString& strXML) { return false; }

public:
	MANUAL_DISPATCH stManualDispatch[5];
};
}