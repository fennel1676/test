#pragma once

#include "../MessageInfo.h"

namespace Message
{
class CMsgFlowRecipeControlCommand : public IMessageInfo
{
public:
	CMsgFlowRecipeControlCommand(void);
	virtual ~CMsgFlowRecipeControlCommand(void);

public:
	virtual const CString GetMsg() { return _T(""); }
	virtual bool ParseMsg(const CString& strXML);

public:
	int nCommandID;
	int nFlowNo;
	CString strFlowID;
	int nRevision;
	CString strTime;
	short nBody[10];
};
}