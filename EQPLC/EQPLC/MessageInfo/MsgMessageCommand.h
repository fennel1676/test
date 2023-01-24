#pragma once

#include "../MessageInfo.h"

namespace Message
{
class CMsgMessageCommand : public IMessageInfo
{
public:
	CMsgMessageCommand(void);
	virtual ~CMsgMessageCommand(void);

public:
	virtual const CString GetMsg() { return _T(""); }
	virtual bool ParseMsg(const CString& strXML);

public:
	int nNum;
	CString strTerminal;
	CString strOPCall;
};
}