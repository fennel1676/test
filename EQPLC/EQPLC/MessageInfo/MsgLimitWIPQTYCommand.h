#pragma once

#include "../MessageInfo.h"

namespace Message
{
	class CMsgLimitWIPQTYCommand : public IMessageInfo
	{
	public:
		CMsgLimitWIPQTYCommand(void);
		virtual ~CMsgLimitWIPQTYCommand(void);

	public:
		virtual const CString GetMsg() { return _T(""); }
		virtual bool ParseMsg(const CString& strXML);

	public:
		int nLimitWIPQTY1;
		int nLimitWIPQTY2;
	};
}