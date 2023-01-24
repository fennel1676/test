#pragma once

#include "MessageInfo.h"

namespace Message
{
class CMsgInitGlassDataReport : public IMessageInfo
{
public:
	CMsgInitGlassDataReport(void);
	virtual ~CMsgInitGlassDataReport(void);

public:
	virtual const CString GetMsg();
	virtual bool ParseMsg(const CString& strXML) { return false; }

public:
};
}
