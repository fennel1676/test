#pragma once

#include "../MessageInfo.h"

namespace Message
{
	class CMsgConnectionEvent : public IMessageInfo
	{

	public:
		CMsgConnectionEvent(void);
		virtual ~CMsgConnectionEvent(void);

	public:
		virtual const CString GetMsg();
		virtual bool ParseMsg(const CString& strXML) { return false; }

	public:
		int m_nResult;
	};
}
