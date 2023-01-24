#pragma once

#include "../MessageInfo.h"

namespace Message
{
class CMsgManualDispatchCommand : public IMessageInfo
{
public:
	CMsgManualDispatchCommand(void);
	virtual ~CMsgManualDispatchCommand(void);

public:
	virtual const CString GetMsg() { return _T(""); }
	virtual bool ParseMsg(const CString& strXML);

public:
	short nDispatchOption;
	CString strDeviceID;
	short nRunLine;
	short nTargetUnit;
};
}