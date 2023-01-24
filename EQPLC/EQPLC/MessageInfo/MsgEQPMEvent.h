#pragma once


#include "../MessageInfo.h"

namespace Message
{
class CMsgEQPMEvent : public IMessageInfo
{
public:
	CMsgEQPMEvent(void);
	virtual ~CMsgEQPMEvent(void);

public:
	virtual const CString GetMsg();
	virtual bool ParseMsg(const CString& strXML) { return false; }

public:
	CString strPMCode;
};
}