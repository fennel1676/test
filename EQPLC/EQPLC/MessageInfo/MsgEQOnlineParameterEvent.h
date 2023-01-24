#pragma once


#include "../MessageInfo.h"

namespace Message
{
class CMsgEQOnlineParameterEvent : public IMessageInfo
{
public:
	CMsgEQOnlineParameterEvent(void);
	virtual ~CMsgEQOnlineParameterEvent(void);

public:
	virtual const CString GetMsg();
	virtual bool ParseMsg(const CString& strXML) { return false; }

public:
	short nEventID;
	short nJudgement;
	short nVcrNo;
	short nVCRMode;
	short nWaitTime;
	short nWIPQTYMode;
	short nByWho;
};
}
