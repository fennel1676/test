#pragma once

#include "../MessageInfo.h"

namespace Message
{
class CMsgFlowGroupEvent : public IMessageInfo
{
public:
	CMsgFlowGroupEvent(void);
	virtual ~CMsgFlowGroupEvent(void);

public:
	virtual const CString GetMsg();
	virtual bool ParseMsg(const CString& strXML) { return false; }

public:
	short nEventID;
	short nOrder[10];
};
}