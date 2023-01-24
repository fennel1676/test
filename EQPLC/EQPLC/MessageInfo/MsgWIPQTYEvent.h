#pragma once
#include "../MessageInfo.h"

namespace Message
{
	class CMsgWIPQTYEvent : public IMessageInfo
	{
	public:
		CMsgWIPQTYEvent(void);
		virtual ~CMsgWIPQTYEvent(void);

	public:
		virtual const CString GetMsg();
		virtual bool ParseMsg(const CString& strXML) { return false; }

	public:
		CString strWIPQTY1PLC1;
		CString strWIPQTY1PLC2;
		CString strWIPQTY2PLC1;
		CString strWIPQTY2PLC2;
	};
}