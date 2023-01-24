#pragma once

#include "../MessageInfo.h"

namespace Message
{
class CMsgDateTimeCommand : public IMessageInfo
{
public:
	CMsgDateTimeCommand(void);
	virtual ~CMsgDateTimeCommand(void);

public:
	virtual const CString GetMsg() { return _T(""); }
	virtual bool ParseMsg(const CString& strXML);

public:
	CString strDateTime;
};
}