#pragma once

#include "../MessageInfo.h"

namespace Message
{
class CMsgEquipmentCommand : public IMessageInfo
{
public:
	CMsgEquipmentCommand(void);
	virtual ~CMsgEquipmentCommand(void);

public:
	virtual const CString GetMsg() { return _T(""); }
	virtual bool ParseMsg(const CString& strXML);

public:
	int nCommandID;
	CString strCode;
	int nNum;
	CString strTerminal;
	CString strOPCall;
	int nByWho;
};
}