#pragma once

#include "../MessageInfo.h"

namespace Message
{
class CMsgPanelIDEvent : public IMessageInfo
{

public:
	CMsgPanelIDEvent(void);
	virtual ~CMsgPanelIDEvent(void);

public:
	virtual const CString GetMsg();
	virtual bool ParseMsg(const CString& strXML) { return false; }

public:
	int m_nPort;
};
}
