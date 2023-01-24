#pragma once

#include "../MessageInfo.h"

namespace Message
{
class CMsgFlowGroupControlCommand : public IMessageInfo
{
public:
	CMsgFlowGroupControlCommand(void);
	virtual ~CMsgFlowGroupControlCommand(void);

public:
	virtual const CString GetMsg() { return _T(""); }
	virtual bool ParseMsg(const CString& strXML);
public:
	int nCommandID;
	short nBody[10];
};
}