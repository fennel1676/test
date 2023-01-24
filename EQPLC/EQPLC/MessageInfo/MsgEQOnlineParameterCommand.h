#pragma once

#include "../MessageInfo.h"

namespace Message
{
class CMsgEQOnlineParameterCommand : public IMessageInfo
{
public:
	CMsgEQOnlineParameterCommand(void);
	virtual ~CMsgEQOnlineParameterCommand(void);

public:
	virtual const CString GetMsg() { return _T(""); }
	virtual bool ParseMsg(const CString& strXML);

public:
	short nCommandID;
	short nJudgement;
	short nVCRMode;
	short nWaitTime;
	short nWIPQTY;
	short nByWho;
};
}